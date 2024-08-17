using LabAutomata.Db.common;
using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabAutomata.Db.configurations {
	internal class Dht22SensorConfiguration : IEntityTypeConfiguration<Dht22Sensor> {
		public void Configure (EntityTypeBuilder<Dht22Sensor> builder) {
			builder.Property(data => data.Id).UseIdentityAlwaysColumn();

			builder.ToTable("dht22_sensors", C.DbSchema);

			builder.HasMany(s => s.Data)
				.WithOne(dh => dh.Dht22Sensor)
				.HasForeignKey(dht => dht.Dht22SensorId);
		}
	}
}
