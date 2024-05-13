using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LabAutomata.Db.common {
    public interface ILabPostgreSqlDbContext {
        public DbSet<SteadyStateTemperatureTest> SsTempTests { get; }

        public PostgreSqlDbContext PostgreSqlDb { get; }
    }

    public class LabPostgreSqlDbContext : PostgreSqlDbContext, ILabPostgreSqlDbContext {
        public DbSet<SteadyStateTemperatureTest> SsTempTests { get; private set; }
        public PostgreSqlDbContext PostgreSqlDb => this;

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
