using MQTTnet;

namespace LabAutomata.IoT;

public class GetDatastreamPayloads : IMqttMsg {
	public MqttApplicationMessage Get () {
		var applicationMessage = new MqttApplicationMessageBuilder()
			.WithTopic("get/ds")
			.WithPayload("temperature_sys_1")
			.Build();

		return applicationMessage;
	}
}