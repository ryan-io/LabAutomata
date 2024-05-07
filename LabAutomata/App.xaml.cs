using Microsoft.Extensions.Configuration;
using System.IO;
using System.Windows;

namespace LabAutomata {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        protected override void OnStartup (StartupEventArgs e) {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddUserSecrets<App>()
                .Build();
            
            )
        }
    }
}
