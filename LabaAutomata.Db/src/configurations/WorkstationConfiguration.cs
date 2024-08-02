//using LabAutomata.Db.models;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace LabAutomata.Db.configurations;

//internal class WorkstationConfiguration : IEntityTypeConfiguration<Workstation> {

//	public void Configure (EntityTypeBuilder<Workstation> builder) {
//		builder.HasOne(e => e.Location)
//			.WithMany()
//			.HasForeignKey(e => e.LocationId);

//		builder.HasMany(e => e.Types)
//			.WithMany();

//		builder.HasMany(e => e.Equipment)
//			.WithMany(e => e.Workstations);
//	}
//}