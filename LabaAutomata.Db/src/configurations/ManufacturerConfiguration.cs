using LabAutomata.Db.common;
using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabAutomata.Db.configurations;

internal class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer> {

	public void Configure (EntityTypeBuilder<Manufacturer> builder) {
		builder.HasOne(e => e.Location);
		builder.ToTable("manufacturers", C.DbSchema);
	}
}