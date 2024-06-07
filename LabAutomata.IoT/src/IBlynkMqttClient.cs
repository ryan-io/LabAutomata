namespace LabAutomata.IoT;

/// <summary>
/// Represents an interface for an MQTT client that connects to the Blynk broker.
/// </summary>
public interface IBlynkMqttClient {
	/// <summary>
	/// Connects to the Blynk broker.
	/// </summary>
	/// <param name="subscription">Topics to subscribe to</param>
	/// <param name="token">Cancellation token to cancel the connection process.</param>
	/// <returns>A task that represents the asynchronous connection operation. The task result contains a boolean value indicating whether the connection was successful.</returns>
	Task<bool> Connect (MqttSubcription subscription = (MqttSubcription.Uplink & MqttSubcription.Downlink), CancellationToken token = default);

	/// <summary>
	/// Disconnects from the Blynk broker.
	/// </summary>
	/// <returns>A task that represents the asynchronous disconnection operation.</returns>
	Task Disconnect (CancellationToken token = default);

	/// <summary>
	/// Disposes the MQTT client and releases any resources used.
	/// </summary>
	void Dispose ();
}