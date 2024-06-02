using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Threading;

namespace LabAutomata.setup {
	internal sealed class StartupEntryPoint : IStartupEntry {
		public void Startup () {
			_app.DispatcherUnhandledException += Application_DispatcherUnhandledException;
			AppDomain.CurrentDomain.UnhandledException += UnhandledShutdown;
			var mw = _sp.GetService<MainWindow>();
			mw?.Show();
		}

		internal StartupEntryPoint (App app, IServiceProvider sp) {
			_app = app;
			_sp = sp;
		}

		private void Application_DispatcherUnhandledException (object sender, DispatcherUnhandledExceptionEventArgs e) {
			e.Handled = true;
		}

		//TODO: research what really happens during an unexpected shutdown of the application
		private void UnhandledShutdown (object sender, UnhandledExceptionEventArgs e) {
			MessageBox.Show($"Is Terminating: {e.IsTerminating}\r\n{e.ExceptionObject}");
		}

		private readonly App _app;
		private readonly IServiceProvider _sp;
	}

	internal interface IStartupEntry {
		void Startup ();
	}
}
