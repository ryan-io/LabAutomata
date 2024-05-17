using LabAutomata.common;
using LabAutomata.Db.common;
using LabAutomata.Db.service;
using LabAutomata.Wpf.Library.viewmodel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using riolog;
using System.Windows;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace LabAutomata {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        public App () {
            var sc = new ServiceCollection();
            ConfigureServices(sc);
            _serviceProvider = sc.BuildServiceProvider();
        }

        protected override void OnStartup (StartupEventArgs e) {
            base.OnStartup(e);

            var mw = _serviceProvider.GetService<MainWindow>();
            mw?.Show();
        }

        void ConfigureServices (IServiceCollection sc) {
            sc.AddTransient<MainWindow>();
            sc.AddSingleton<IConfiguration>(_ => new ConfigurationService().Create<App>());
            sc.AddSingleton<LabPostgreSqlDbContext>();

            //sc.AddTransient<IPrimaryVm, MainWindowVm>();
            sc.AddTransient<IWorkRequestVm, WorkRequestVm>();
            sc.AddTransient<IHomeVm, HomeVm>();
            sc.AddTransient<ICreateWorkRequestVm, CreateWorkRequestVm>();

            var logPath = AppC.GetRootPath() + @"\logging\log_.txt";
            sc.AddSingleton<ILogger>(_ => InternalLogFactory.SetupAndStart(Output.All, logPath).AsLogger<App>());
        }

        private readonly IServiceProvider _serviceProvider;

        private void ApplicationClose (object sender, ExitEventArgs e) {
            var logger = _serviceProvider.GetService<ILogger>();
            logger?.LogInformation("Application now closing.");
            logger?.LogInformation("Closing DbContext");
            var ctx = _serviceProvider.GetService<LabPostgreSqlDbContext>();
            ctx?.Dispose();
            logger?.CloseAndFlush();
        }
    }
}