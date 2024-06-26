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

public class GetTimestampPayload : IMqttMsg {

	public MqttApplicationMessage Get () {
		var applicationMessage = new MqttApplicationMessageBuilder()
			.WithTopic("get/ds")
			.WithPayload("timestamp")
			.Build();

		return applicationMessage;
	}
}