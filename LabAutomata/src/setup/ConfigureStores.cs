using LabAutomata.Wpf.Library.contracts;
using LabAutomata.Wpf.Library.mediator_stores;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LabAutomata.setup;

internal sealed class ConfigureStores {
	public void Configure () {
		_sc.AddSingleton<DhtSensorStore>();
		_sc.AddSingleton<IDht22PayloadData>(
			sp => sp.GetRequiredService<DhtSensorStore>());

		_sc.AddSingleton<DhtSensorDataWriter>();
		_sc.AddSingleton<IDhtSensorDataWriter>(
			sp => sp.GetRequiredService<DhtSensorDataWriter>());


		_sc.AddSingleton<WorkstationStore>();
		_sc.AddSingleton<IWorkstationStore>(sp => sp.GetRequiredService<WorkstationStore>());
	}

	public ConfigureStores (IServiceCollection sc, IConfigurationBuilder cb) {
		_sc = sc;
		_cb = cb;
	}

	private readonly IServiceCollection _sc;
	private readonly IConfigurationBuilder _cb;
}