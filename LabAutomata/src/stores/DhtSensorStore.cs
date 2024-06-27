using LabAutomata.IoT;
using LabAutomata.Wpf.Library.contracts;
using MQTTnet.Client;
using Newtonsoft.Json;

namespace LabAutomata.stores;

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