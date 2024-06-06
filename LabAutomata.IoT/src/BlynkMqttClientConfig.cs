namespace LabAutomata.IoT;

/// <summary>
/// Represents the configuration for a Blynk MQTT client.
/// </summary>
public class BlynkMqttClientConfig {
	/// <summary>
	/// Gets the MQTT broker address.
	/// </summary>
	public string Broker { get; init; }

	/// <summary>
	/// Gets the client ID.
	/// </summary>
	public string Id { get; init; }

	/// <summary>
	/// Gets the client password.
	/// </summary>
	public string Password { get; init; }

	/// <summary>
	/// Gets the MQTT broker port.
	/// </summary>
	public int Port { get; init; }
}
