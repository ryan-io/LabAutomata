using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LabAutomata.Db.common {
    public abstract class PostgreSqlDbContext : DbContext {
        public IConfiguration? Configuration { get; init; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            //base.OnConfiguring(optionsBuilder);
            // gets connection string from our appsettings.json

            if (Configuration == null)
                return;

            optionsBuilder.UseNpgsql(Configuration.GetConnectionString(LAB_POSTGRES_DATABASE_CONNECTION));
        }

        public PostgreSqlDbContext () {

        }

        public PostgreSqlDbContext (IConfiguration config) {
            Configuration = config;
        }

        internal const string LAB_POSTGRES_DATABASE_CONNECTION = "LabDatabase";
    }
}
