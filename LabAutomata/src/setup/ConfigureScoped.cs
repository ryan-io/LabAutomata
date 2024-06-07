using LabAutomata.common;
using LabAutomata.IoT;
using LabAutomata.Wpf.Library.common;
using LabAutomata.Wpf.Library.viewmodel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MQTTnet;
using riolog;

namespace LabAutomata.setup;

internal sealed class ConfigureScoped {
	private readonly IServiceCollection _sc;

	public void Configure () {
		var logPath = AppC.GetRootPath() + @"\logging\log_.txt"; //TODO - change where the log path points to?
		_sc.AddScoped(_ => InternalLogFactory.SetupAndStart(Output.All, logPath).AsLogger<App>());

		// reflection to get all classes in deriving from the Base view model class within the LabAutomata.Wpf.Library asm
		var asmViewModels = typeof(Base).Assembly.GetSubclassOf<Base>().ToList();

		foreach (var vmType in asmViewModels) {
			_sc.AddScoped(vmType);
		}

		_sc.AddScoped(_ => {
			var factory = new MqttFactory();
			return factory.CreateMqttClient();
		});

		// scoped
		_sc.AddScoped<IBlynkMqttClientConfig>(sp => {
			var config = sp.GetRequiredService<IConfigurationRoot>();

			ArgumentNullException.ThrowIfNull(config, CouldNotExtractConfigFromServiceProvider);

			var client = new BlynkMqttClientConfig {
				Broker = config[Broker]!,
				Id = config[Id]!,
				Password = config[Password]!,
				Port = Convert.ToInt32(config[Port])
			};

			return client;
		});
	}

	public ConfigureScoped (IServiceCollection sc) {
		_sc = sc;
	}

	private const string Broker = "BlynkConfig:Broker";
	private const string Id = "BlynkConfig:Id";
	private const string Password = "BlynkConfig:Password";
	private const string Port = "BlynkConfig:Port";
	private const string CouldNotExtractConfigFromServiceProvider = "Could not extract config from service provider.";
}