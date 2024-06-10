using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabAutomata.Db.configurations {

	internal class TestConfiguration : IEntityTypeConfiguration<Test> {

		public void Configure (EntityTypeBuilder<Test> builder) {
			builder.HasIndex(e => e.InstanceId).IsUnique();
			builder.HasMany(e => e.Workstations)
				.WithMany(e => e.Tests);
			builder.HasOne(e => e.Location)
				.WithMany()
				.HasForeignKey(e => e.LocationId);
			builder.HasOne(e => e.Type)
				.WithMany()
				.HasForeignKey(e => e.TypeId);
			builder.HasOne(e => e.Operator)
				.WithMany()
				.HasForeignKey(e => e.OperatorId);
		}
	}
}