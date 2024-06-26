using LabAutomata.IoT;

namespace LabAutomata.Wpf.Library.contracts;

public interface IDht22Payload {
	event Action<MqttDht22Payload>? PayloadDeserialized;
}