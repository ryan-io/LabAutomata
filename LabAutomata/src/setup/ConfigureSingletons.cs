using LabAutomata.common;
using LabAutomata.Db.common;
using LabAutomata.IoT;
using LabAutomata.Wpf.Library.data_structures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MQTTnet;
using rio_command_pipeline;
using riolog;

namespace LabAutomata.setup;

/// <summary>
/// Class responsible for configuring singletons in the application.
/// Any persistent state should be registered with the service provider as a singleton
/// </summary>
internal sealed class ConfigureSingletons {
	private readonly IServiceCollection _sc;
	private readonly IConfigurationBuilder _cb;

	/// <summary>
	/// Initializes a new instance of the <see cref="ConfigureSingletons"/> class.
	/// </summary>
	/// <param name="sc">The service collection.</param>
	/// <param name="cb">The configuration builder.</param>
	public ConfigureSingletons (IServiceCollection sc, IConfigurationBuilder cb) {
		_sc = sc;
		_cb = cb;
	}

	/// <summary>
	/// Configures the singletons.
	/// </summary>
	public void Configure () {
		_sc.AddSingleton(_ => _cb.Build());
		_sc.AddSingleton(_ => new ConfigurationService().Create<App>());
		_sc.AddSingleton(_ => new CommandPipelineBroker(AppEvent.CLOSED, AppEvent.STARTED));
		_sc.AddSingleton(sp => sp); // little trick to simply return a singleton to our Sp instance
		_sc.AddSingleton<IBlynkMqttClient, BlynkMqttClient>();
		_sc.AddSingleton<IVmc, Vmc>();
		_sc.AddSingleton<BlynkMqttPoll>();

		var logPath = AppC.GetRootPath() + @"\logging\log_.txt"; //TODO - change where the log path points to?
		_sc.AddSingleton(_ => InternalLogFactory.SetupAndStart(Output.All, logPath).AsLogger<App>());

		_sc.AddSingleton(_ => {
			var factory = new MqttFactory();
			return factory.CreateMqttClient();
		});
	}
}
