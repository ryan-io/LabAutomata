using LabAutomata.common;
using LabAutomata.IoT;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using rio_command_pipeline;
using System.Windows;
using System.Windows.Threading;

namespace LabAutomata.setup {
	/// <summary>
	/// Represents the startup entry point of the application.
	/// </summary>
	internal sealed class StartupEntryPoint : IStartupEntry {
		/// <summary>
		/// Starts the application, sets up global exception handlers, and shows the main window.
		/// </summary>
		public async Task Startup (CancellationToken token = default) {
			_app.DispatcherUnhandledException += Application_DispatcherUnhandledException;
			AppDomain.CurrentDomain.UnhandledException += UnhandledShutdown;
			var mw = _sp.GetService<MainWindow>();
			mw?.Show();

			var mqttClient = _sp.GetRequiredService<IBlynkMqttClient>();
			var clientState = await mqttClient.Connect(MqttSubcription.Downlink | MqttSubcription.Uplink, token);

			_logger.LogInformation("State return from MQTT client connection: {state}", clientState);

			var broker = _sp.GetRequiredService<CommandPipelineBroker>();
			await broker.SignalAsync(AppEvent.STARTED, token: token);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="StartupEntryPoint"/> class.
		/// </summary>
		/// <param name="app">The application instance.</param>
		/// <param name="sp">The service provider to resolve services.</param>
		internal StartupEntryPoint (App app, IServiceProvider sp) {
			_app = app;
			_sp = sp;
			_logger = sp.GetRequiredService<ILogger>();
		}

		/// <summary>
		/// Handles unhandled exceptions thrown on the dispatcher thread.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The event data.</param>
		private void Application_DispatcherUnhandledException (object sender, DispatcherUnhandledExceptionEventArgs e) {
			e.Handled = true;
		}

		/// <summary>
		/// Handles unhandled exceptions thrown on any thread.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The event data.</param>
		private void UnhandledShutdown (object sender, UnhandledExceptionEventArgs e) {
			MessageBox.Show($"Is Terminating: {e.IsTerminating}\r\n{e.ExceptionObject}");
		}

		private readonly App _app;
		private readonly IServiceProvider _sp;
		private readonly ILogger _logger;
	}

	/// <summary>
	/// Defines a contract for a startup entry point.
	/// </summary>
	internal interface IStartupEntry {
		/// <summary>
		/// Starts the application.
		/// </summary>
		Task Startup (CancellationToken token = default);
	}
}
