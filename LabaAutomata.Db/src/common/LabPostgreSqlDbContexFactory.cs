﻿using LabAutomata.Db.src.service;
using Microsoft.EntityFrameworkCore.Design;

namespace LabAutomata.Db.src.common {
    internal class LabPostgreSqlDbContexFactory : IDesignTimeDbContextFactory<LabPostgreSqlDbContext> {
        public LabPostgreSqlDbContext CreateDbContext (string[] args) {
            var config = new ConfigurationService().Create<LabPostgreSqlDbContexFactory>();
            var cs = new LabConnectionString();

            var ctx = new LabPostgreSqlDbContext() { Configuration = config, ConnectionString = cs };
            return ctx;

        }

    }
}