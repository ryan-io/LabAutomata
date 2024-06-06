using Microsoft.Extensions.Logging;
using MQTTnet;
using MQTTnet.Client;

namespace LabAutomata.IoT {
	/// <summary>
	/// Represents an interface for an MQTT client that connects to the Blynk broker.
	/// </summary>
	public interface IBlynkMqttClient {
		/// <summary>
		/// Connects to the Blynk broker.
		/// </summary>
		/// <param name="token">Cancellation token to cancel the connection process.</param>
		/// <returns>A task that represents the asynchronous connection operation. The task result contains a boolean value indicating whether the connection was successful.</returns>
		Task<bool> Connect (CancellationToken token = default);

		/// <summary>
		/// Disconnects from the Blynk broker.
		/// </summary>
		/// <returns>A task that represents the asynchronous disconnection operation.</returns>
		Task Disconnect (CancellationToken token = default);

		/// <summary>
		/// Disposes the MQTT client and releases any resources used.
		/// </summary>
		void Dispose ();
	}

	public class BlynkMqttClient : IDisposable, IBlynkMqttClient {
		/// <summary>
		/// Establishes an MQTT connection with the Blynk broker
		/// </summary>
		public BlynkMqttClient (BlynkMqttClientConfig config, ILogger? logger = default) {
			// reference https://github.com/dotnet/MQTTnet/blob/master/Samples/ManagedClient/Managed_Client_Simple_Samples.cs
			var factory = new MqttFactory();
			_client = factory.CreateMqttClient();
			_config = config;
			_logger = logger;
		}

		/// <summary>
		/// Attempts to establish a connection to a Blynk IoT device using the provided credentials
		/// via MQTT
		/// This method can throw an error if bad credentials are provided and should be wrapped in a try-catch
		/// </summary>
		/// <param name="token"></param>
		/// <returns></returns>
		public async Task<bool> Connect (CancellationToken token = default) {
			//var tlsClientOptions = new MqttClientTlsOptionsBuilder();
			//tlsClientOptions.UseTls().WithTargetHost();

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

			var result = await _client.ConnectAsync(mqttClientOptions, token);
			return true;
		}

		/// <summary>
		/// Disconnects from the MQTT server (broker)
		/// </summary>
		public async Task Disconnect (CancellationToken token = default) {

			await _client.DisconnectAsync(cancellationToken: token);
		}

		public void Dispose () {
			if (IsDisposed) return;
			IsDisposed = true;
			_client.Dispose();
		}

		bool IsDisposed { get; set; }

		readonly IMqttClient _client;
		private readonly ILogger? _logger;
		private readonly BlynkMqttClientConfig _config;
	}
}
