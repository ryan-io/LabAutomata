using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LabAutomata.Db.common {
	public interface ILabPostgreSqlDbContext {
		DbSet<WorkRequest> WorkRequests { get; }
		DbSet<Workstation> Workstations { get; }
		DbSet<Personnel> Personnels { get; }
		DbSet<Equipment> Equipment { get; }
		DbSet<Test> Test { get; }
		DbSet<Manufacturer> Manufacturers { get; }
		DbSet<SeedJson> SeedJson { get; }
		DbSet<TestType> TestType { get; }
		DbSet<WorkstationType> WorkstationTypesType { get; }
		DbSet<Location> Location { get; }
		PostgreSqlDbContext PostgreSqlDb { get; }
	}

	public class LabPostgreSqlDbContext : PostgreSqlDbContext, ILabPostgreSqlDbContext {
		public DbSet<WorkRequest> WorkRequests { get; set; }
		public DbSet<Workstation> Workstations { get; set; }
		public DbSet<Equipment> Equipment { get; set; }
		public DbSet<Test> Test { get; set; }
		public DbSet<Manufacturer> Manufacturers { get; set; }
		public DbSet<TestType> TestType { get; set; }
		public DbSet<WorkstationType> WorkstationTypesType { get; set; }
		public DbSet<Location> Location { get; set; }
		public DbSet<Personnel> Personnels { get; set; }
		public DbSet<SeedJson> SeedJson { get; set; }
		public PostgreSqlDbContext PostgreSqlDb => this;

		public LabPostgreSqlDbContext (IConfiguration config) : base(config) { }

		protected override void OnModelCreating (ModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfigurationsFromAssembly(typeof(LabPostgreSqlDbContext).Assembly);
		}
	}
}
