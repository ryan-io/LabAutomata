using LabAutomata.Db.common;
using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabAutomata.Db.configurations;

internal class WorkstationTypeConfiguration : IEntityTypeConfiguration<WorkstationType> {
	public void Configure (EntityTypeBuilder<WorkstationType> builder) {
		builder.ToTable("workstation_types", C.DbSchema);
	}
}