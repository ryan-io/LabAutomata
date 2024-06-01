using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabAutomata.Db.configurations;

internal class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer> {
    public void Configure (EntityTypeBuilder<Manufacturer> builder) {
        builder.HasMany(e => e.WorkRequests)
            .WithOne(e => e.Manufacturer)
            .HasForeignKey(e => e.ManufacturerId)
            .HasPrincipalKey(e => e.Id)
            .IsRequired();

        builder.HasOne(e => e.Location)
            .WithMany()
            .HasForeignKey(e => e.LocationId);
    }
}