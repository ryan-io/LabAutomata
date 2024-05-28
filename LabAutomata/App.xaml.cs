using LabAutomata.common;
using LabAutomata.Db.common;
using LabAutomata.Db.models;
using LabAutomata.Db.repository;
using LabAutomata.Db.service;
using LabAutomata.Wpf.Library.adapter;
using LabAutomata.Wpf.Library.common;
using LabAutomata.Wpf.Library.data_structures;
using LabAutomata.Wpf.Library.viewmodel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using riolog;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace LabAutomata {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        public App () {
            var sc = new ServiceCollection();
            var vmTypes = ConfigureServices(sc);
            _serviceProvider = sc.BuildServiceProvider();
            BuildVmc(vmTypes);
        }

        protected override void OnStartup (StartupEventArgs e) {
            base.OnStartup(e);
            //TODO: research what really happens during an unexpected shutdown of the application
            DispatcherUnhandledException += Application_DispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += UnhandledShutdown;
            var mw = _serviceProvider.GetService<MainWindow>();
            mw?.Show();
        }

        private void Application_DispatcherUnhandledException (object sender,
            System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e) {
            e.Handled = true;
        }

        private void UnhandledShutdown (object sender, UnhandledExceptionEventArgs e) {
            MessageBox.Show($"Is Terminating: {e.IsTerminating}\r\n{e.ExceptionObject}");
        }

        // For DbContext: define user secrets for "LabDatabase"
        //	Get assembly from App.xaml.xs
        //	Create a new configuration builder
        //  Invoke AddUserSecrets on the builder
        //	Call c.Builder and register it as a service

        List<Type> ConfigureServices (IServiceCollection sc) {
            var asm = Assembly.GetCallingAssembly();
            ArgumentNullException.ThrowIfNull(asm, "Lab Db assembly cannot be null");

            var c = new ConfigurationBuilder();
            c.AddUserSecrets(asm);
            sc.AddSingleton<IConfiguration>(sp => c.Build());
            sc.AddSingleton(_ => new ConfigurationService().Create<App>());
            sc.AddDbContext<ILabPostgreSqlDbContext, LabPostgreSqlDbContext>();
            sc.AddSingleton(sp => sp); // little trick to simply return a singleton to our Sp instance
            sc.AddTransient<MainWindow>();

            // reflection to get all classes in deriving from the Base view model class within the LabAutomata.Wpf.Library asm
            var asmViewModels = typeof(Base).Assembly.GetSubclassOf<Base>().ToList();

            foreach (var vmType in asmViewModels) {
                sc.AddSingleton(vmType);
            }

            sc.AddTransient<IAdapter<Dispatcher>>(_ => new DispatcherAdapter(Current));
            sc.AddTransient<IRepository<WorkRequest>, WorkRequestRepository>();
            sc.AddTransient<IRepository<Workstation>, WorkstationRepository>();
            sc.AddSingleton<IRepository<SeedJson>, SeedDataRepository>();
            sc.AddSingleton<IRepository<Test>, TestRepository>();
            sc.AddSingleton<IRepository<Manufacturer>, ManufacturerRepository>();

            sc.AddTransient<IRepositoryCreate<SeedJson>>(sp => sp.GetRequiredService<IRepository<SeedJson>>());
            sc.AddTransient<IRepositoryGet<SeedJson>>(sp => sp.GetRequiredService<IRepository<SeedJson>>());

            var logPath = AppC.GetRootPath() + @"\logging\log_.txt"; //TODO - change where the log path points to?
            sc.AddSingleton(_ => InternalLogFactory.SetupAndStart(Output.All, logPath).AsLogger<App>());
            return asmViewModels;
        }

        private void BuildVmc (List<Type> vmTypes) {
            foreach (var vmType in vmTypes) {
                Vmc.Instance.Add(vmType.Name, (_serviceProvider.GetService(vmType) as Base)!);
            }
        }

        private void ApplicationClose (object sender, ExitEventArgs e) {
            var logger = _serviceProvider.GetService<ILogger>();
            logger?.LogInformation("Application now closing.");
            logger?.LogInformation("Closing DbContext");
            var ctx = _serviceProvider.GetService<LabPostgreSqlDbContext>();
            ctx?.Dispose();
            logger?.CloseAndFlush();
        }

        private readonly IServiceProvider _serviceProvider;
    }
}