using LabAutomata.setup;
using System.Windows;

namespace LabAutomata {
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application {
		public App () {
			ConfigurationEntryPoint entry = new(Current);
			_serviceProvider = entry.Configure(this);
		}

		/// <summary>
		/// Overrides the OnStartup method to perform startup operations.
		/// </summary>
		/// <param name="e">The event arguments.</param>
		protected override async void OnStartup (StartupEventArgs e) {
			base.OnStartup(e);

			IStartupEntry entry = new StartupEntryPoint(this, _serviceProvider);
			await entry.Startup(CancellationToken.None);
		}

		/// <summary>
		/// Overrides the OnExit method to perform shutdown operations.
		/// </summary>
		/// <param name="e">The event arguments.</param>
		protected override async void OnExit (ExitEventArgs e) {
			base.OnExit(e);

			IShutdownEntryPoint entry = new ShutdownEntryPoint(_serviceProvider);
			await entry.Shutdown(CancellationToken.None);
		}

		private readonly IServiceProvider _serviceProvider;
	}
}