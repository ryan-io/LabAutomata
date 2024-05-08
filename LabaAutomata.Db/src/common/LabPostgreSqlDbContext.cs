﻿using LabAutomata.Library.src.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LabAutomata.Db.src.common {
    public class LabPostgreSqlDbContext : PostgreSqlDbContext {
        public DbSet<Test> Tests { get; set; }

        public LabPostgreSqlDbContext () : base() { }

        public LabPostgreSqlDbContext (IConfiguration config) : base(config) { }

        void GetTests () {
            Tests.Single(t => t.Id == 444);
        }
    }
}
