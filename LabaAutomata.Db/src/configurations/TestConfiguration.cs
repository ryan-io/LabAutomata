using LabAutomata.Db.common;
using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabAutomata.Db.configurations;

internal class TestConfiguration : IEntityTypeConfiguration<Test> {

	public void Configure (EntityTypeBuilder<Test> builder) {
		builder.HasIndex(e => e.InstanceId).IsUnique();

		builder.HasMany(e => e.Workstations)
			.WithMany(e => e.Tests);

		builder.HasOne(e => e.WorkRequest);
		builder.HasOne(e => e.Location);
		builder.HasOne(e => e.Type);
		builder.HasOne(e => e.Operator);

		builder.ToTable("tests", C.DbSchema);
	}

}