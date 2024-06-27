using LabAutomata.stores;
using LabAutomata.Wpf.Library.contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LabAutomata.setup;

internal sealed class ConfigureStores {
	public void Configure () {
		_sc.AddSingleton<DhtSensorStore>();
		_sc.AddSingleton<IDht22PayloadData>(sp => sp.GetRequiredService<DhtSensorStore>());
		_sc.AddSingleton<DhtSensorDbWriteStore>();
	}

	public ConfigureStores (IServiceCollection sc, IConfigurationBuilder cb) {
		_sc = sc;
		_cb = cb;
	}

	private readonly IServiceCollection _sc;
	private readonly IConfigurationBuilder _cb;
}