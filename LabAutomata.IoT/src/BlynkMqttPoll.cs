using MQTTnet.Client;

namespace LabAutomata.IoT;

/// <summary>
/// Represents a Blynk MQTT poll.
/// </summary>
public class BlynkMqttPoll {
	private readonly IMqttClient _client;

	/// <summary>
	/// Initializes a new instance of the <see cref="BlynkMqttPoll"/> class.
	/// </summary>
	/// <param name="client">The MQTT client.</param>
	public BlynkMqttPoll (IMqttClient client) {
		_client = client;
	}

	/// <summary>
	/// Sends a signal to the MQTT client.
	/// </summary>
	/// <param name="msgPayload">Interface for retrieving an appropriate message payload</param>
	/// <param name="token">The cancellation token.</param>
	public async Task Signal (IMqttMsg msgPayload, CancellationToken token = default) {
		await _client.PublishAsync(msgPayload.Get(), token);
	}
}