using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabAutomata.Db.configurations;

internal class EquipmentConfiguration : IEntityTypeConfiguration<Equipment> {

	public void Configure (EntityTypeBuilder<Equipment> builder) {
		builder.HasMany(e => e.Workstations)
			.WithMany(e => e.Equipment);
		builder.HasOne(e => e.Manufacturer)
			.WithMany()
			.HasForeignKey(e => e.ManufacturerId);
		builder.Property(e => e.PurchaseDate)
			.IsRequired();
	}
}