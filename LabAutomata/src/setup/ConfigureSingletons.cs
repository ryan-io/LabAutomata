using LabAutomata.common;
using LabAutomata.Db.common;
using LabAutomata.IoT;
using LabAutomata.stores;
using LabAutomata.Wpf.Library.contracts;
using LabAutomata.Wpf.Library.data_structures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MQTTnet;
using rio_command_pipeline;

namespace LabAutomata.setup;

internal sealed class ConfigureSingletons {

	public void Configure () {
		_sc.AddSingleton(_ => _cb.Build());
		_sc.AddSingleton(_ => new ConfigurationService().Create<App>());
		_sc.AddSingleton(_ => new CommandPipelineBroker(AppEvent.CLOSED, AppEvent.STARTED));
		_sc.AddSingleton(sp => sp); // little trick to simply return a singleton to our Sp instance
		_sc.AddSingleton<IBlynkMqttClient, BlynkMqttClient>();
		_sc.AddSingleton<IVmc, Vmc>();
		_sc.AddSingleton<DhtSensorStore>();
		_sc.AddSingleton<IDht22Payload>(sp => sp.GetRequiredService<DhtSensorStore>());
		_sc.AddSingleton(_ => {
			var factory = new MqttFactory();
			return factory.CreateMqttClient();
		});

		_sc.AddSingleton<BlynkMqttPoll>();
	}

	public ConfigureSingletons (IServiceCollection sc, IConfigurationBuilder cb) {
		_sc = sc;
		_cb = cb;
	}

	private readonly IServiceCollection _sc;
	private readonly IConfigurationBuilder _cb;
}