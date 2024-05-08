using LabAutomata.Library.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LabAutomata.Db.common {
    public class LabPostgreSqlDbContext : PostgreSqlDbContext {
        public DbSet<SteadyStateTemperatureTest> SsTempTests { get; set; }

        internal LabPostgreSqlDbContext () : base() {

        }

        public LabPostgreSqlDbContext (IConfiguration config) : base(config) {

        }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SteadyStateTemperatureTest>(
                e => {
                    e.HasMany(t => t.Data);
                });
        }
    }
}
