using LabAutomata.DataAccess.service;
using LabAutomata.DataAccess.unit_of_work;
using LabAutomata.Wpf.Library.adapter;
using LabAutomata.Wpf.Library.common;
using Microsoft.Extensions.DependencyInjection;
using rbcl;
using System.Windows;
using System.Windows.Threading;

namespace LabAutomata.setup;

internal sealed class ConfigureTransient {
	private readonly IServiceCollection _sc;

	public void Configure () {
		_sc.AddTransient<MainWindow>();
		_sc.AddTransient<IAdapter<Dispatcher>>(_ => new DispatcherAdapter(_app));

		// database repositories
		_sc.AddTransient<IVmIdExtractor, VmIdExtractor>();

		// services
		_sc.AddTransient<IEquipmentService, EquipmentService>();
		_sc.AddTransient<IWorkRequestService, WorkRequestService>();
		_sc.AddTransient<IDht22DataService, Dht22DataService>();
		_sc.AddTransient<IDht22SensorService, Dht22SensorService>();
		_sc.AddTransient<ILocationService, LocationService>();
		_sc.AddTransient<IWorkstationService, WorkstationService>();

		_sc.AddTransient<IJsonValidator>(_ => new JsonValidator(
			[new ValidateIsJsonObject()],
			[new ValidateNoApostrophe()]));

		// units of work
		_sc.AddTransient<IDht22SensorDataUnitOfWork, Dht22SensorDataUnitOfWork>();
	}

	public ConfigureTransient (IServiceCollection sc, Application app) {
		_sc = sc;
		_app = app;
	}

	private Application _app;
}