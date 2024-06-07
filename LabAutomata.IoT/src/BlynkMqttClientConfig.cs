namespace LabAutomata.IoT;

public interface IBlynkMqttClientConfig {
	/// <summary>
	/// Gets the MQTT broker address.
	/// </summary>
	string Broker { get; init; }

	/// <summary>
	/// Gets the client ID.
	/// </summary>
	string Id { get; init; }

	/// <summary>
	/// Gets the client password.
	/// </summary>
	string Password { get; init; }

	/// <summary>
	/// Gets the MQTT broker port.
	/// </summary>
	int Port { get; init; }
}

/// <summary>
/// Represents the configuration for a Blynk MQTT client.
/// </summary>
public class BlynkMqttClientConfig : IBlynkMqttClientConfig {
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
