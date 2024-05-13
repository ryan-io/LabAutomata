using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LabAutomata.Db.common {
    /// <summary>
    /// Represents a base class for a PostgreSQL database context.
    /// </summary>
    public abstract class PostgreSqlDbContext : DbContext {
        /// <summary>
        /// Gets or sets the configuration object used to retrieve the connection string.
        /// </summary>
        public IConfiguration? Configuration { get; init; }

        /// <summary>
        /// Configures the database connection using the provided options builder.
        /// </summary>
        /// <param name="optionsBuilder">The options builder used to configure the database connection.</param>
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            if (Configuration == null)
                return;

            // Gets the connection string from the appsettings.json file
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString(LAB_POSTGRES_DATABASE_CONNECTION));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostgreSqlDbContext"/> class.
        /// </summary>
        public PostgreSqlDbContext () {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PostgreSqlDbContext"/> class with the specified configuration.
        /// </summary>
        /// <param name="config">The configuration object used to retrieve the connection string.</param>
        public PostgreSqlDbContext (IConfiguration config) {
            Configuration = config;
        }

        internal const string LAB_POSTGRES_DATABASE_CONNECTION = "LabDatabase";
    }
}
