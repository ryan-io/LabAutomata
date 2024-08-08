using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabAutomata.Db.configurations;

internal class WorkstationConfiguration : IEntityTypeConfiguration<Workstation> {

	public void Configure (EntityTypeBuilder<Workstation> builder) {
		//builder.HasOne(e => e.Location)
		//	.WithMany()
		//	.HasForeignKey(e => e.Location!.Id);    // null suppression here

		//TODO: redefine these navigation collections once they are implemented

		//builder.HasMany(e => e.Types)
		//	.WithMany();

		//builder.HasMany(e => e.Equipment)
		//	.WithMany(e => e.Workstations);
	}
}