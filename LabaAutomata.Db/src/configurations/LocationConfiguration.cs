using LabAutomata.Db.common;
using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabAutomata.Db.configurations;

internal class LocationConfiguration : IEntityTypeConfiguration<Location> {
	public void Configure (EntityTypeBuilder<Location> builder) {
		builder.ToTable("location", C.DbSchema);
	}
}