using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LabAutomata.Db.common {
	public class LabPostgreSqlDbContext : PostgreSqlDbContext, ILabPostgreSqlDbContext {
		public DbSet<WorkRequest> WorkRequests { get; set; }
		public DbSet<Workstation> Workstations { get; set; }
		public DbSet<Equipment> Equipment { get; set; }
		public DbSet<Test> Test { get; set; }
		public DbSet<Manufacturer> Manufacturers { get; set; }
		public DbSet<TestType> TestType { get; set; }
		public DbSet<WorkstationType> WorkstationTypesType { get; set; }
		public DbSet<Location> Location { get; set; }
		public DbSet<DhtSensor> DhtSensors { get; }
		public DbSet<DhtJsonData> DhtJsonData { get; }
		public DbSet<Personnel> Personnels { get; set; }
		public DbSet<SeedJson> SeedJson { get; set; }
		public PostgreSqlDbContext PostgreSqlDb => this;

		public LabPostgreSqlDbContext (IConfiguration config) : base(config) {
		}

		protected override void OnModelCreating (ModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(LabPostgreSqlDbContext).Assembly);
		}
	}
}