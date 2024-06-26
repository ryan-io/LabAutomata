using LabAutomata.IoT;
using Microsoft.Extensions.DependencyInjection;
using MQTTnet.Client;

namespace LabAutomata.setup;

/// <summary>
/// Represents the entry point for MQTT communication in the application.
/// This class holds onto a dedicated thread and blocks it to keep it clear for MQTT communication.
/// </summary>
public class MqttEntryPoint {
	private readonly IServiceProvider _sp;
	//private readonly SemaphoreSlim _semaphore;

	/// <summary>
	/// Initializes a new instance of the <see cref="MqttEntryPoint"/> class.
	/// </summary>
	/// <param name="sp">The service provider.</param>
	public MqttEntryPoint (IServiceProvider sp) {
		_sp = sp;
		//_semaphore = new SemaphoreSlim(1, 1);
	}

	/// <summary>
	/// Starts the MQTT background thread for periodic work.
	/// </summary>
	/// <param name="appCancellationToken">The cancellation token for the application.</param>
	public void Startup (CancellationToken appCancellationToken) {
		//var logger = _sp.GetRequiredService<ILogger>();
		var client = _sp.GetRequiredService<IMqttClient>();
		var poll = new BlynkMqttPoll(client);

		IMqttMsg timestampPayload = new GetTimestampPayload();
		IMqttMsg dataPayloads = new GetDatastreamPayloads();

		Task.Run(async () => {
			while (!appCancellationToken.IsCancellationRequested) {
				await poll.Signal(dataPayloads, appCancellationToken);
				await poll.Signal(timestampPayload, appCancellationToken);
			}

		}, appCancellationToken);
	}
}