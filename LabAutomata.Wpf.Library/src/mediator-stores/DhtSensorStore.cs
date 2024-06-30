using LabAutomata.IoT;
using LabAutomata.Wpf.Library.contracts;
using Microsoft.Extensions.Logging;
using MQTTnet.Client;
using Newtonsoft.Json;

namespace LabAutomata.Wpf.Library.mediator_stores;

public class DhtSensorStore : IDht22PayloadData {
	public event Action<MqttDht22Payload>? PayloadDeserialized;

	void NotifyPayloadDeserialzied (MqttApplicationMessageReceivedEventArgs args) {
		if (args.ApplicationMessage.Topic.Equals(DhtSensor1)) {
			var output = _interpretation.Interpret(args);

			if (output.ResponseObject != null) {
				var payload = JsonConvert.DeserializeObject<MqttDht22Payload>(output.ResponseObject);

				if (payload == null) {
					throw new NullReferenceException($"{nameof(MqttDht22Payload)} was null");
				}

				payload.Raw = output.ResponseObject;
				var list = PayloadDeserialized.GetInvocationList();
				var count = list.Length;

				foreach (var @delegate in list) {
					var name = @delegate.Method.Name;
				}

				PayloadDeserialized?.Invoke(payload);
			}
		}
	}

	/// <summary>
	/// This is typically registered as a Singleton and explicit invocation is not required
	/// IF this is registered as transient, it will need to be explicitly invoked
	/// this is to ensure we do not have any dangling references
	/// </summary>
	public void Dispose () {
		_client.MessageReceived -= NotifyPayloadDeserialzied;
	}

	public DhtSensorStore (IBlynkMqttClient client, ILogger logger1, ILogger? logger = default) {
		_interpretation = new JsonInterpretation();
		_client = client;
		_logger = logger1;
		_client.MessageReceived += NotifyPayloadDeserialzied;
	}

	private readonly JsonInterpretation _interpretation;
	private readonly IBlynkMqttClient _client;
	readonly ILogger _logger;
	private const string DhtSensor1 = "downlink/ds/temperature_sys_1";

}