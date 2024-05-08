using LabAutomata.Db.service;
using Microsoft.EntityFrameworkCore.Design;

namespace LabAutomata.Db.common {
    internal class LabPostgreSqlDbContexFactory : IDesignTimeDbContextFactory<LabPostgreSqlDbContext> {
        public LabPostgreSqlDbContext CreateDbContext (string[] args) {
            var config = new ConfigurationService().Create<LabPostgreSqlDbContexFactory>();

            var ctx = new LabPostgreSqlDbContext() { Configuration = config };
            return ctx;

        }

    }
}