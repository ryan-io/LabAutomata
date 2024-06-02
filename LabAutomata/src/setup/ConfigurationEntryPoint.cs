using LabAutomata.common;
using LabAutomata.Db.common;
using LabAutomata.Db.models;
using LabAutomata.Db.repository;
using LabAutomata.Wpf.Library.adapter;
using LabAutomata.Wpf.Library.common;
using LabAutomata.Wpf.Library.data_structures;
using LabAutomata.Wpf.Library.viewmodel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using riolog;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;

namespace LabAutomata.setup;

internal sealed class ConfigurationEntryPoint {
	public IServiceProvider Configure () {
		var sc = new ServiceCollection();
		var vms = ConfigureServices(sc);
		var sp = sc.BuildServiceProvider();

		var vmc = sp.GetRequiredService<IVmc>();

		foreach (var vmType in vms) {
			vmc.Set(vmType.Name, (sp.GetService(vmType) as Base)!);
		}

		return sp;
	}

	List<Type> ConfigureServices (IServiceCollection sc) {
		var asm = Assembly.GetCallingAssembly();
		ArgumentNullException.ThrowIfNull(asm, "Lab Db assembly cannot be null");

		var c = new ConfigurationBuilder();

		// For DbContext: define user secrets for "LabDatabase"
		//	Get assembly from App.xaml.xs
		//	Create a new configuration builder
		//  Invoke AddUserSecrets on the builder
		//	Call c.Builder and register it as a service
		c.AddUserSecrets(asm);
		sc.AddSingleton<IConfiguration>(sp => c.Build());
		sc.AddSingleton(_ => new ConfigurationService().Create<App>());
		sc.AddTransient<ILabPostgreSqlDbContext, LabPostgreSqlDbContext>();
		sc.AddSingleton(sp => sp); // little trick to simply return a singleton to our Sp instance
		sc.AddTransient<MainWindow>();
		sc.AddSingleton<IVmc, Vmc>();
		sc.AddTransient<IAdapter<Dispatcher>>(_ => new DispatcherAdapter(_application));
		sc.AddTransient<IRepository<WorkRequest>, WorkRequestRepository>();
		sc.AddTransient<IRepository<Workstation>, WorkstationRepository>();
		sc.AddTransient<IRepository<Personnel>, PersonnelRepository>();
		sc.AddTransient<IRepository<Location>, LocationRepository>();
		sc.AddTransient<IRepository<TestType>, TestTypeRepository>();
		sc.AddTransient<IRepository<SeedJson>, SeedDataRepository>();
		sc.AddTransient<IRepository<Test>, SteadyStateTemperatureTest>();
		sc.AddTransient<IRepository<Manufacturer>, ManufacturerRepository>();

		sc.AddTransient<IRepositoryCreate<SeedJson>>(sp => sp.GetRequiredService<IRepository<SeedJson>>());
		sc.AddTransient<IRepositoryGet<SeedJson>>(sp => sp.GetRequiredService<IRepository<SeedJson>>());

		var logPath = AppC.GetRootPath() + @"\logging\log_.txt"; //TODO - change where the log path points to?
		sc.AddSingleton(_ => InternalLogFactory.SetupAndStart(Output.All, logPath).AsLogger<App>());

		// reflection to get all classes in deriving from the Base view model class within the LabAutomata.Wpf.Library asm
		var asmViewModels = typeof(Base).Assembly.GetSubclassOf<Base>().ToList();

		foreach (var vmType in asmViewModels) {
			sc.AddSingleton(vmType);
		}

		return asmViewModels;
	}

	internal ConfigurationEntryPoint (Application application) {
		_application = application;
	}

	private readonly Application _application;
}