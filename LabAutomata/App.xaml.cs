using LabAutomata.Db.common;
using LabAutomata.setup;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using riolog;
using System.Windows;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace LabAutomata {
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application {
		public App () {
			ConfigurationEntryPoint entry = new(Current);
			_serviceProvider = entry.Configure();
		}

		protected override void OnStartup (StartupEventArgs e) {
			base.OnStartup(e);

			IStartupEntry entry = new StartupEntryPoint(this, _serviceProvider);
			entry.Startup();
		}

		private void ApplicationClose (object sender, ExitEventArgs e) {
			var logger = _serviceProvider.GetService<ILogger>();
			logger?.LogInformation("Application now closing.");
			logger?.LogInformation("Closing DbContext");
			var ctx = _serviceProvider.GetService<LabPostgreSqlDbContext>();
			ctx?.Dispose();
			logger?.CloseAndFlush();
		}

		private readonly IServiceProvider _serviceProvider;
	}
}