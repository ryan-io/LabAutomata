using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LabAutomata.Db.common {

	/// <summary>
	/// Represents a base class for a PostgreSQL database context.
	/// </summary>
	public class PostgreSqlDbContext : DbContext {
		public DbSet<Dht22Sensor> Dht22Sensors { get; private set; }
		public DbSet<Dht22Data> Dht22Data { get; private set; }
		public DbSet<Location> Location { get; private set; }

		/*
		public DbSet<WorkRequest> WorkRequests { get; set; }
		public DbSet<Workstation> Workstations { get; set; }
		public DbSet<Equipment> Equipment { get; set; }
		public DbSet<Test> Test { get; set; }
		public DbSet<Manufacturer> Manufacturers { get; set; }
		public DbSet<TestType> TestType { get; set; }
		public DbSet<WorkstationType> WorkstationTypesType { get; set; }

		public DbSet<Personnel> Personnels { get; set; }
		public DbSet<SeedJson> SeedJson { get; set; }
		*/

		/// <summary>
		/// Initializes a new instance of the <see cref="PostgreSqlDbContext"/> class with the specified configuration.
		/// </summary>
		/// <param name="config">The configuration object used to retrieve the connection string.</param>
		public PostgreSqlDbContext (IConfiguration config) {
			_configuration = config;
		}

		/// <summary>
		/// Configures the database connection using the provided options builder.
		/// </summary>
		/// <param name="optionsBuilder">The options builder used to configure the database connection.</param>
		protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
			if (_configuration == null)
				return;

			if (!optionsBuilder.IsConfigured) {
				// Gets the connection string from the appsettings.json/secrets.json file
				optionsBuilder.UseNpgsql(_configuration.GetConnectionString(C.DatabaseConnectionId))
					.UseSnakeCaseNamingConvention()
					.EnableDetailedErrors();
			}
		}

		/// <summary>
		/// Applies all configurations located under src/configurations to each model present in the project
		/// </summary>
		protected override void OnModelCreating (ModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgreSqlDbContext).Assembly);
		}

		/// <summary>
		/// Gets or sets the configuration object used to retrieve the connection string.
		/// </summary>
		private readonly IConfiguration? _configuration;
	}
}