using LabAutomata.setup;
using System.Windows;

namespace LabAutomata {
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