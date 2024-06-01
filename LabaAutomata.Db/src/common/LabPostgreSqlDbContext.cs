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
        DbSet<TestType> TestType { get; }
        DbSet<WorkstationType> WorkstationTypesType { get; }
        DbSet<Location> Location { get; }
        PostgreSqlDbContext PostgreSqlDb { get; }
    }

    public class LabPostgreSqlDbContext : PostgreSqlDbContext, ILabPostgreSqlDbContext {
        public DbSet<WorkRequest> WorkRequests { get; set; }
        public DbSet<Workstation> Workstations { get; set; }
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

            modelBuilder.Entity<Test>(etb => {
                etb.HasIndex(e => e.InstanceId).IsUnique();
                etb.HasMany(e => e.Workstations)
                    .WithMany(e => e.Tests);
                etb.HasOne(e => e.Location)
                    .WithMany()
                    .HasForeignKey(e => e.LocationId);
                etb.HasOne(e => e.Type)
                    .WithMany()
                    .HasForeignKey(e => e.TypeId);
                etb.HasOne(e => e.Operator)
                    .WithMany()
                    .HasForeignKey(e => e.OperatorId);
            });

            modelBuilder.Entity<Manufacturer>(etb => {
                etb.HasMany(e => e.WorkRequests)
                    .WithOne(e => e.Manufacturer)
                    .HasForeignKey(e => e.ManufacturerId)
                    .HasPrincipalKey(e => e.Id)
                    .IsRequired();

                etb.HasOne(e => e.Location)
                    .WithMany()
                    .HasForeignKey(e => e.LocationId);
            });

            modelBuilder.Entity<WorkRequest>(etb => {
                etb.HasMany(e => e.Tests)
                    .WithOne(e => e.WorkRequest)
                    .HasForeignKey(e => e.WrId)
                    .HasPrincipalKey(e => e.WrId);
            });

            modelBuilder.Entity<Workstation>(etb => {
                etb.HasOne(e => e.Location)
                    .WithMany()
                    .HasForeignKey(e => e.LocationId);

                etb.HasMany(e => e.Types)
                    .WithMany();
            });

            modelBuilder.Entity<Personnel>(etb => {
                etb.HasOne(e => e.Location)
                    .WithMany()
                    .HasForeignKey(e => e.LocationId);
            });
        }
    }
}
