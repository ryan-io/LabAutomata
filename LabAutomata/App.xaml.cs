﻿using LabAutomata.common;
using LabAutomata.Db.common;
using LabAutomata.Db.service;
using LabAutomata.Wpf.Library.adapter;
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
            ConfigureServices(sc);
            _serviceProvider = sc.BuildServiceProvider();
        }

        protected override void OnStartup (StartupEventArgs e) {
            base.OnStartup(e);

            var mw = _serviceProvider.GetService<MainWindow>();
            mw?.Show();
        }

        void ConfigureServices (IServiceCollection sc) {


            sc.AddSingleton(_ => new ConfigurationService().Create<App>());
            sc.AddSingleton<LabPostgreSqlDbContext>();
            sc.AddSingleton(sp => sp);    // little trick to simply return a singleton to our Sp instance

            sc.AddSingleton<MainWindow>();
            sc.AddSingleton<MainWindowVm>();
            sc.AddSingleton<IWorkRequestVm, WorkRequestVm>();
            sc.AddSingleton<IHomeVm, HomeVm>();
            sc.AddSingleton<ICreateWorkRequestVm, CreateWorkRequestVm>();
            sc.AddSingleton<IAdapter<Dispatcher>>(_ => new DispatcherAdapter(Current));

            var logPath = AppC.GetRootPath() + @"\logging\log_.txt";    //TODO - change where the log path points to?
            sc.AddSingleton(_ => InternalLogFactory.SetupAndStart(Output.All, logPath).AsLogger<App>());

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