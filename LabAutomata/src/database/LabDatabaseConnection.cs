using LabaAutomata.Db.src;
using LabAutomata.src.common;
using Microsoft.Extensions.Configuration;

namespace LabAutomata.src.database {
    internal class LabDatabaseConnection (IConfigurationRoot configuration) : IConnectionString {
        public string? Get => configuration.GetConnectionString(C.LAB_DATABASE_CONNECTION);
    }
}
