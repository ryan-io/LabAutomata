using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LabAutomata.Db.common {
    public interface ILabPostgreSqlDbContext {
        DbSet<WorkRequest> WorkRequests { get; }
        DbSet<Workstation> Workstations { get; }
        DbSet<Personnel> Personnels { get; }
        DbSet<Test> Test { get; }
        DbSet<Manufacturer> Manufacturers { get; }
        DbSet<SeedJson> SeedJson { get; }
        PostgreSqlDbContext PostgreSqlDb { get; }
    }

    public class LabPostgreSqlDbContext : PostgreSqlDbContext, ILabPostgreSqlDbContext {
        public DbSet<WorkRequest> WorkRequests { get; set; }
        public DbSet<Workstation> Workstations { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<SeedJson> SeedJson { get; set; }
        public PostgreSqlDbContext PostgreSqlDb => this;

        public LabPostgreSqlDbContext (IConfiguration config) : base(config) { }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Test>(etb => {
                etb.HasIndex(e => e.InstanceId).IsUnique();
            });

            modelBuilder.Entity<Manufacturer>(etb => {
                etb.HasMany(e => e.WorkRequests)
                    .WithOne(e => e.Manufacturer)
                    .HasForeignKey(e => e.ManufacturerId)
                    .HasPrincipalKey(e => e.Id)
                    .IsRequired();
            });

            modelBuilder.Entity<WorkRequest>(etb => {
                etb.HasMany(e => e.Tests)
                    .WithOne(e => e.WorkRequest)
                    .HasForeignKey(e => e.WrId)
                    .HasPrincipalKey(e => e.WrId);
            });

            modelBuilder.Entity<TemperaturePoint>(etb => {
                etb.HasOne<SteadyStateTemperatureTest>().WithMany().HasForeignKey(e => e.InstanceId);
            });
        }
    }
}
