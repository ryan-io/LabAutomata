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
		var logger = _sp.GetRequiredService<ILogger>();
		var client = _sp.GetRequiredService<IMqttClient>();
		var poll = new BlynkMqttPoll(client);

		IMqttMsg timestampPayload = new GetTimestampPayload();
		IMqttMsg dataPayloads = new GetDatastreamPayloads();

		async Task CallbackTask () {
			await poll.Signal(dataPayloads, appCancellationToken);
			await poll.Signal(timestampPayload, appCancellationToken);
		}

		var onComplete = () => {
			logger.LogInformation("MQTT background thread has stopped.");
			//_semaphore.Release(1);
			//_semaphore.Dispose();
		};

		// this piece of code will await any polling required for subscribed datastreams
		// this step is required... its brittle and I don't really like it at this point in time
		// TODO: this code should be more robust; too much setup prior to arriving to this code
		//			if something fails in the setup... this piece of code simply doesn't work
		Task.Run(async () => {
			while (!appCancellationToken.IsCancellationRequested) {
				await poll.Signal(dataPayloads, appCancellationToken);
				await poll.Signal(timestampPayload, appCancellationToken);
			}

			//_semaphore.Dispose();
		});

		//var periodicWork = new PeriodicWork(CallbackTask, 3);

		//// start background thread... do not await this
		//_ = Task.Run(async () => {
		//	await _semaphore.WaitAsync(appCancellationToken);
		//	await periodicWork.WorkAsync(() =>
		//			appCancellationToken.IsCancellationRequested,
		//			onComplete,
		//			appCancellationToken);
		//}, appCancellationToken);

		//logger.LogInformation("Starting background thread for periodic work.");
	}
}