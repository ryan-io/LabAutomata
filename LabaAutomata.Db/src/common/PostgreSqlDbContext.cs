using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.Db.common {

	/// <summary>
	/// Represents a base class for a PostgreSQL database context.
	/// </summary>
	public class PostgreSqlDbContext : DbContext {
		public DbSet<Dht22Sensor> Dht22Sensors { get; private set; }
		public DbSet<Dht22Data> Dht22Data { get; private set; }
		public DbSet<Location> Locations { get; private set; }
		public DbSet<Manufacturer> Manufacturers { get; private set; }
		public DbSet<WorkRequest> WorkRequests { get; set; }
		public DbSet<Workstation> Workstations { get; set; }

		/*
		public DbSet<Equipment> Equipment { get; set; }
		public DbSet<Test> Test { get; set; }
		public DbSet<TestType> TestType { get; set; }
		public DbSet<WorkstationType> WorkstationTypesType { get; set; }

		public DbSet<Personnel> Personnels { get; set; }
		public DbSet<SeedJson> SeedJson { get; set; }
		*/


		public PostgreSqlDbContext (DbContextOptions options) : base(options) {

		}

		/// <summary>
		/// Empty constructor: EF Core scaffolding with code first migrations
		/// </summary>
		public PostgreSqlDbContext () {

		}

		/// <summary>
		/// Configures the database connection using the provided options builder.
		/// </summary>
		/// <param name="optionsBuilder">The options builder used to configure the database connection.</param>
		protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
#if DEBUG
			//Gets the connection string from the appsettings.json / secrets.json file
			optionsBuilder.UseNpgsql("Host=localhost;Database=lab;username=postgres;Password=Dev.Internal9911!;IncludeErrorDetail=true")
				.UseSnakeCaseNamingConvention()
				.EnableDetailedErrors();
#endif
		}

		/// <summary>
		/// Applies all configurations located under src/configurations to each model present in the project
		/// </summary>
		protected override void OnModelCreating (ModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgreSqlDbContext).Assembly);
		}
	}
}