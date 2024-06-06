namespace LabAutomata.IoT;

/// <summary>
/// Represents the configuration for a Blynk MQTT client.
/// </summary>
public readonly struct BlynkMqttClientConfig {
	/// <summary>
	/// Gets the MQTT broker address.
	/// </summary>
	public string Broker { get; }

	/// <summary>
	/// Gets the client ID.
	/// </summary>
	public string Id { get; }

	/// <summary>
	/// Gets the client password.
	/// </summary>
	public string Password { get; }

	/// <summary>
	/// Gets the MQTT broker port.
	/// </summary>
	public int Port { get; }
}
