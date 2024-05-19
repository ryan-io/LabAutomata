using LabAutomata.common;
using LabAutomata.Db.common;
using LabAutomata.Db.service;
using LabAutomata.Wpf.Library.adapter;
using LabAutomata.Wpf.Library.common;
using LabAutomata.Wpf.Library.data_structures;
using LabAutomata.Wpf.Library.viewmodel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using riolog;
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

            var mw = _serviceProvider.GetService<MainWindow>();
            mw?.Show();
        }

        List<Type> ConfigureServices (IServiceCollection sc) {
            sc.AddSingleton(_ => new ConfigurationService().Create<App>());
            sc.AddSingleton<LabPostgreSqlDbContext>();
            sc.AddSingleton(sp => sp);    // little trick to simply return a singleton to our Sp instance
            sc.AddTransient<MainWindow>();

            // reflection to get all classes in deriving from the Base view model class within the LabAutomata.Wpf.Library asm
            var asmViewModels = typeof(Base).Assembly.GetSubclassOf<Base>().ToList();

            foreach (var vmType in asmViewModels) {
                sc.AddSingleton(vmType);
            }

            sc.AddTransient<IAdapter<Dispatcher>>(_ => new DispatcherAdapter(Current));

            var logPath = AppC.GetRootPath() + @"\logging\log_.txt";    //TODO - change where the log path points to?
            sc.AddSingleton(_ => InternalLogFactory.SetupAndStart(Output.All, logPath).AsLogger<App>());
            return asmViewModels;
        }

        //static bool IsTypeBaseVm (Type type) => type.IsOfBase(typeof(Base));

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