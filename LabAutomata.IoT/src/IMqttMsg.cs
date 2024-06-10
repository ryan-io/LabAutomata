using MQTTnet;

namespace LabAutomata.IoT;

public interface IMqttMsg {

	MqttApplicationMessage Get ();
}