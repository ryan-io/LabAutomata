using LabAutomata.Db.common;
using LabAutomata.Db.service;
using LabAutomata.Library.models;
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
            var t = SteadyStateTemperatureTest.New(Random.Shared.Next(00000, 99999));
            t.Data.Add(new TemperaturePoint() {
                InstanceId = t.InstanceId,
                Timestamp = DateTime.UtcNow,
                Value = 100.2f,
                Unit = TemperatureUnit.Celcius
            });
            var ctx = _serviceProvider.GetService<LabPostgreSqlDbContext>();
            ctx.SsTempTests.Add(t);
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
            sc.AddSingleton<LabPostgreSqlDbContext>();
        }

        private readonly IServiceProvider _serviceProvider;

        private void ApplicationClose (object sender, ExitEventArgs e) {
            var ctx = _serviceProvider.GetService<LabPostgreSqlDbContext>();
            ctx?.Dispose();
        }
    }
}