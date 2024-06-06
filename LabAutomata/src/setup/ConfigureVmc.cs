using LabAutomata.Wpf.Library.common;
using LabAutomata.Wpf.Library.data_structures;
using LabAutomata.Wpf.Library.viewmodel;
using Microsoft.Extensions.DependencyInjection;

namespace LabAutomata.setup;

internal sealed class ConfigureVmc {
	private readonly IServiceProvider _sp;

	public void Configure () {
		var asmViewModels = typeof(Base).Assembly.GetSubclassOf<Base>().ToList();
		var vmc = _sp.GetRequiredService<IVmc>();

		foreach (var vmType in asmViewModels) {
			vmc.Set(vmType.Name, (_sp.GetService(vmType) as Base)!);
		}

	}

	public ConfigureVmc (IServiceProvider sp) {
		_sp = sp;
	}
}