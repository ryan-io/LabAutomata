using LabAutomata.common;
using LabAutomata.IoT;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using rio_command_pipeline;
using riolog;
using DhtSensorStore = LabAutomata.Wpf.Library.mediator_stores.DhtSensorStore;

namespace LabAutomata.setup {

	/// <summary>
	/// Represents the shutdown entry point of the application.
	/// </summary>
	internal sealed class ShutdownEntryPoint {

		/// <summary>
		/// Initializes a new instance of the <see cref="ShutdownEntryPoint"/> class.
		/// </summary>
		public ShutdownEntryPoint (IServiceProvider sp) {
			_sp = sp;
		}

		/// <summary>
		/// Initiates the shutdown process of the application.
		/// </summary>
		/// <param name="token">A cancellation token that can be used to cancel the shutdown process.</param>
		/// <returns>A task that represents the asynchronous shutdown operation.</returns>
		public async Task Shutdown (CancellationToken token = default) {
			var broker = _sp.GetRequiredService<CommandPipelineBroker>();
			await broker.SignalAsync(AppEvent.CLOSED, token: token);

			var client = _sp.GetRequiredService<IBlynkMqttClient>();
			await client.Disconnect();

			var dhtStore = _sp.GetRequiredService<DhtSensorStore>();
			//dhtStore?.Dispose();

			var logger = _sp.GetService<ILogger>();
			logger?.LogInformation("Application now closing.");
			logger?.LogInformation("Closing DbContext");
			logger?.CloseAndFlush();
		}

		private readonly IServiceProvider _sp;
	}
}