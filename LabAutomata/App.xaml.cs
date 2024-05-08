using LabAutomata.Db.src.abstraction;
using LabAutomata.Db.src.common;
using LabAutomata.Db.src.service;
using LabAutomata.Library.src.models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace LabAutomata {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        public App () {
            var sc = new ServiceCollection();
            ConfigureServices(sc);
            _serviceProvider = sc.BuildServiceProvider();

            var ctx = _serviceProvider.GetService<LabPostgreSqlDbContext>();
            ctx.Tests.Add(Test.CreateInstance("PTC"));
            ctx.SaveChanges();
        }

        //protected override void OnStartup (StartupEventArgs e) {
        //    var conf = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //        .AddUserSecrets<App>()
        //        .Build();

        //    var dbCtx = new LabDbContext(new LabDatabaseConnection(conf), conf);
        //}

        void ConfigureServices (IServiceCollection sc) {
            sc.AddSingleton<IConfiguration>(_ => new ConfigurationService().Create<App>());
            sc.AddTransient<IConnectionString, LabConnectionString>();
            sc.AddSingleton<LabPostgreSqlDbContext>();
        }

        private readonly IServiceProvider _serviceProvider;

        private void ApplicationClose (object sender, ExitEventArgs e) {
            var ctx = _serviceProvider.GetService<LabPostgreSqlDbContext>();
            ctx?.Dispose();
        }
    }
}