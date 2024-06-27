using LabAutomata.IoT;
using LabAutomata.Wpf.Library.contracts;
using MQTTnet.Client;
using Newtonsoft.Json;

namespace LabAutomata.Wpf.Library.mediator_stores;

public class DhtSensorStore : IDisposable, IDht22PayloadData {
	public event Action<MqttDht22Payload>? PayloadDeserialized;

	void NotifyPayloadDeserialzied (MqttApplicationMessageReceivedEventArgs args) {
		if (args.ApplicationMessage.Topic.Equals(DhtSensor1)) {
			var output = _interpretation.Interpret(args);

			if (output.ResponseObject != null) {
				var payload = JsonConvert.DeserializeObject<MqttDht22Payload>(output.ResponseObject);
				PayloadDeserialized?.Invoke(payload);

				// move this to appropriate class
				//_observableValues.Add(new DateTimePoint(date, payload.Temperature));
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

	public DhtSensorStore (IBlynkMqttClient client) {
		_interpretation = new JsonInterpretation();
		_client = client;
		_client.MessageReceived += NotifyPayloadDeserialzied;
	}

	private readonly JsonInterpretation _interpretation;
	private readonly IBlynkMqttClient _client;
	private const string DhtSensor1 = "downlink/ds/temperature_sys_1";

}