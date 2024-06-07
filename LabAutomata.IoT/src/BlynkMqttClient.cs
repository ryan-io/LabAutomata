using Microsoft.Extensions.Logging;
using MQTTnet;
using MQTTnet.Client;

namespace LabAutomata.IoT {
	/// <summary>
	/// Represents a Blynk MQTT client.
	/// </summary>
	public class BlynkMqttClient : IDisposable, IBlynkMqttClient {
		private readonly IMqttClient _client;
		private readonly ILogger? _logger;
		private readonly IBlynkMqttClientConfig _config;

		/// <summary>
		/// Initializes a new instance of the <see cref="BlynkMqttClient"/> class.
		/// </summary>
		/// <param name="client">The MQTT client.</param>
		/// <param name="config">The Blynk MQTT client configuration.</param>
		/// <param name="logger">The logger.</param>
		public BlynkMqttClient (IMqttClient? client, IBlynkMqttClientConfig config, ILogger? logger = default) {
			if (client == null) {
				var factory = new MqttFactory();
				_client = factory.CreateMqttClient();
			}
			else {
				_client = client;
			}

			_config = config;
			_logger = logger;
		}

		/// <summary>
		/// Attempts to establish a connection to a Blynk IoT device using the provided credentials via MQTT.
		/// </summary>
		/// <param name="subscription">The MQTT subscription.</param>
		/// <param name="token">The cancellation token.</param>
		/// <returns>A task representing the connection result.</returns>
		public async Task<bool> Connect (MqttSubcription subscription = (MqttSubcription.Uplink | MqttSubcription.Downlink), CancellationToken token = default) {
			var mqttClientOptions = new MqttClientOptionsBuilder()
				.WithTcpServer(_config.Broker, _config.Port)
				.WithCredentials(_config.Id, _config.Password)
				.WithKeepAlivePeriod(TimeSpan.FromSeconds(45))
				.WithCleanSession()
				.Build();

			if (_logger != null) {
				_client.ConnectedAsync += _ => {
					_logger.LogInformation("Connected to {iot}", _config.Broker);
					return Task.CompletedTask;
				};

				_client.DisconnectedAsync += _ => {
					_logger.LogInformation("Disconnected from {iot}", _config.Broker);
					return Task.CompletedTask;
				};
			}

			var interpreter = new BlynkMqttInterpreter(_logger);
			_client.ApplicationMessageReceivedAsync += e => {
				interpreter.Interpret(new Utf8MqttInterpretation(), e);
				return Task.CompletedTask;
			};

			var result = await _client.ConnectAsync(mqttClientOptions, token);
			var topicSubscriber = new MqttTopicSubscriber(_logger);

			await _client.SubscribeAsync(topicSubscriber.Subscribe(subscription), token);
			var applicationMessage = new MqttApplicationMessageBuilder()
				.WithTopic("get/ds")
				.WithPayload("temperature_sys_2")
				.Build();

			await _client.PublishAsync(applicationMessage, token);
			return result.IsSessionPresent;
		}

		/// <summary>
		/// Disconnects from the MQTT server (broker).
		/// </summary>
		/// <param name="token">The cancellation token.</param>
		/// <returns>A task representing the disconnection result.</returns>
		public async Task Disconnect (CancellationToken token = default) {
			await _client.DisconnectAsync(cancellationToken: token);
		}

		/// <summary>
		/// Disposes the MQTT client.
		/// </summary>
		public void Dispose () {
			if (IsDisposed) return;
			IsDisposed = true;
			_client.Dispose();
		}

		/// <summary>
		/// Gets or sets a value indicating whether the MQTT client is disposed.
		/// </summary>
		bool IsDisposed { get; set; }
	}
}
