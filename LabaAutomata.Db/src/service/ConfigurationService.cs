using Microsoft.Extensions.Configuration;

namespace LabAutomata.Db.service {
    public class ConfigurationService {
        public IConfiguration Create<T> () where T : class {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddUserSecrets<T>()
                .Build();

            return builder;
        }

        public ConfigurationService () {

        }
    }
}
