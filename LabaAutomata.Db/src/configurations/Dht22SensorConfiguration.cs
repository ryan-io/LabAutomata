using LabAutomata.Db.common;
using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabAutomata.Db.configurations {
	internal class Dht22SensorConfiguration : IEntityTypeConfiguration<Dht22Sensor> {

		public void Configure (EntityTypeBuilder<Dht22Sensor> builder) {
			builder.HasMany(s => s.Data)
				.WithOne(d => d.Dht22Sensor)
				.HasForeignKey(data => data.Id);

			builder.ToTable("dht22_sensors", C.DbSchema);
		}
	}
}
