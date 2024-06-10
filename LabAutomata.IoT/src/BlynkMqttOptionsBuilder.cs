using MQTTnet.Client;

namespace LabAutomata.IoT;

public class BlynkMqttOptionsBuilder {

	/// <summary>
	/// Builds the MQTT client options based on the provided configuration.
	/// </summary>
	/// <param name="config">The Blynk MQTT client configuration.</param>
	/// <returns>The MQTT client options.</returns>
	public MqttClientOptions BuildOptions (IBlynkMqttClientConfig config) {
		return new MqttClientOptionsBuilder()
			.WithTcpServer(config.Broker, config.Port)
			.WithCredentials(config.Id, config.Password)
			.WithKeepAlivePeriod(TimeSpan.FromSeconds(AliveTimeSeconds))
			.WithCleanSession()
			.Build();
	}

	private const int AliveTimeSeconds = 45;
}