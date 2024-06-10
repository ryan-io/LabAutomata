using Microsoft.Extensions.Logging;
using MQTTnet;
using MQTTnet.Client;

namespace LabAutomata.IoT;

public class MqttTopicSubscriber {

	public MqttTopicSubscriber (ILogger? logger) {
		_logger = logger;
	}

	public MqttClientSubscribeOptions Subscribe (MqttSubcription subcription) {
		var mqttFactory = new MqttFactory();
		var mqttSubscribeOptions = mqttFactory.CreateSubscribeOptionsBuilder();

		if ((subcription & MqttSubcription.None) != 0) {
			_logger?.LogInformation("No subscriptions for Blynk via MQTT will be registered.");
			return mqttSubscribeOptions.Build();
		}

		if ((subcription & MqttSubcription.Downlink) != 0) {
			_logger?.LogInformation("Subscribed to downlink MQTT messages from Blynk.");
			mqttSubscribeOptions.WithTopicFilter(filter => filter.WithTopic("downlink/#"));
		}

		if ((subcription & MqttSubcription.Uplink) != 0) {
			_logger?.LogInformation("Subscribed to uplink MQTT messages from Blynk.");
			mqttSubscribeOptions.WithTopicFilter(filter => filter.WithTopic("uplink/#"));
		}

		return mqttSubscribeOptions.Build();
	}

	private readonly ILogger? _logger;
}