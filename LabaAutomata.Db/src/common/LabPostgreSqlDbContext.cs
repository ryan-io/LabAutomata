using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LabAutomata.Db.common {
    public interface ILabPostgreSqlDbContext {
        DbSet<WorkRequest> WorkRequests { get; }
        DbSet<Workstation> Workstations { get; }
        DbSet<Personnel> Personnels { get; }
        DbSet<SteadyStateTemperatureTest> SsTempTests { get; }
        DbSet<SeedJson> SeedJson { get; }
        PostgreSqlDbContext PostgreSqlDb { get; }
    }

    public class LabPostgreSqlDbContext : PostgreSqlDbContext, ILabPostgreSqlDbContext {
        public DbSet<WorkRequest> WorkRequests { get; set; }
        public DbSet<Workstation> Workstations { get; set; }
        public DbSet<SteadyStateTemperatureTest> SsTempTests { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<SeedJson> SeedJson { get; set; }
        public PostgreSqlDbContext PostgreSqlDb => this;

        public LabPostgreSqlDbContext (IConfiguration config) : base(config) { }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SteadyStateTemperatureTest>(
                e => {
                    e.HasMany(t => t.Data);
                });

            modelBuilder.Entity<Manufacturer>(etb => {
                etb.HasMany(e => e.WorkRequests)
                    .WithOne(e => e.Manufacturer)
                    .HasForeignKey(e => e.ManufacturerId)
                    .HasPrincipalKey(e => e.Id);
            });
        }
    }
}
