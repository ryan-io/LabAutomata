using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabAutomata.Db.configurations {

	internal class DhtSensorConfiguration : IEntityTypeConfiguration<DhtSensor> {

		public void Configure (EntityTypeBuilder<DhtSensor> builder) {
			builder.HasMany(s => s.Data)
				.WithOne(d => (DhtSensor)d.DataContainer)
				.HasForeignKey(d => d.OwnerId);
		}
	}
}
