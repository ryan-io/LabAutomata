using LabAutomata.IoT;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MQTTnet.Client;

namespace LabAutomata.setup;

/// <summary>
/// Represents the entry point for MQTT communication in the application.
/// This class holds onto a dedicated thread and blocks it to keep it clear for MQTT communication.
/// </summary>
public class MqttEntryPoint {
	private readonly IServiceProvider _sp;
	private readonly ILogger? _logger;
	//private readonly SemaphoreSlim _semaphore;

	/// <summary>
	/// Initializes a new instance of the <see cref="MqttEntryPoint"/> class.
	/// </summary>
	/// <param name="sp">The service provider.</param>
	public MqttEntryPoint (IServiceProvider sp) {
		_sp = sp;
		_logger = _sp.GetRequiredService<ILogger>();
		//_semaphore = new SemaphoreSlim(1, 1);
	}

	/// <summary>
	/// Starts the MQTT background thread for periodic work.
	/// </summary>
	/// <param name="appCancellationToken">The cancellation token for the application.</param>
	public void Startup (CancellationToken appCancellationToken) {
		var logger = _sp.GetRequiredService<ILogger>();
		var client = _sp.GetRequiredService<IMqttClient>();
		var poll = new BlynkMqttPoll(client, logger);

		IMqttMsg dataPayloads = new GetDatastreamPayloads();

		Task.Run(async () => {
			try {
				while (!appCancellationToken.IsCancellationRequested) {
					await poll.Signal(dataPayloads, appCancellationToken);
				}
			}
			catch (Exception e) {
				_logger?.LogError("Async error: " + e.Message);
			}
		});
	}
}