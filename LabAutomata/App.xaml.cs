using LabAutomata.IoT;
using LabAutomata.Library.common;
using LabAutomata.setup;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MQTTnet.Client;
using System.Windows;

namespace LabAutomata {
	public class MqttEntryPoint {
		private readonly IServiceProvider _sp;

		public MqttEntryPoint (IServiceProvider sp) {
			_sp = sp;
		}

		public void Startup (CancellationToken appCancellationToken) {
			var logger = _sp.GetRequiredService<ILogger>();
			var client = _sp.GetRequiredService<IMqttClient>();
			var poll = new BlynkMqttPoll(client);

			IMqttMsg payload = new GetDatastreamPayloads();

			var callbackTask = async () => await poll.Signal(payload, appCancellationToken);
			var onComplete = () => logger.LogInformation("MQTT background thread has stopped.");
			var periodicWork = new PeriodicWork(callbackTask);

			// start background thread... do not await this
			_ = Task.Run(async () => {
				await periodicWork.WorkAsync(() =>
					appCancellationToken.IsCancellationRequested,
					onComplete,
					appCancellationToken);
			});

			logger.LogInformation("Starting background thread for periodic work.");
		}
	}

	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application {
		public App () {
			ConfigurationEntryPoint entry = new(Current);
			_serviceProvider = entry.Configure();
		}

		/// <summary>
		/// Overrides the OnStartup method to perform startup operations.
		/// </summary>
		/// <param name="e">The event arguments.</param>
		protected override async void OnStartup (StartupEventArgs e) {
			base.OnStartup(e);

			IStartupEntry entry = new StartupEntryPoint(this, _serviceProvider);
			await entry.Startup(CancellationToken.None);

			var mqttEntryPoint = new MqttEntryPoint(_serviceProvider);
			mqttEntryPoint.Startup(_tokenSource.Token);
		}

		/// <summary>
		/// Overrides the OnExit method to perform shutdown operations.
		/// </summary>
		/// <param name="e">The event arguments.</param>
		protected override async void OnExit (ExitEventArgs e) {
			base.OnExit(e);
			await _tokenSource.CancelAsync();
			_tokenSource?.Dispose();
			IShutdownEntryPoint entry = new ShutdownEntryPoint(_serviceProvider);
			await entry.Shutdown(CancellationToken.None);
		}

		private readonly CancellationTokenSource _tokenSource = new();
		private readonly IServiceProvider _serviceProvider;
	}
}