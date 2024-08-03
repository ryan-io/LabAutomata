using LabAutomata.Wpf.Library.adapter;
using LabAutomata.Wpf.Library.common;
using Microsoft.Extensions.DependencyInjection;
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
	}

	public ConfigureTransient (IServiceCollection sc, Application app) {
		_sc = sc;
		_app = app;
	}

	private Application _app;
}