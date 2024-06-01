using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabAutomata.Db.configurations;

internal class WorkRequestConfiguration : IEntityTypeConfiguration<WorkRequest> {
    public void Configure (EntityTypeBuilder<WorkRequest> builder) {
        builder.HasMany(e => e.Tests)
            .WithOne(e => e.WorkRequest)
            .HasForeignKey(e => e.WrId)
            .HasPrincipalKey(e => e.WrId);
    }
}