using LabAutomata.Db.common;
using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabAutomata.Db.configurations;

internal class Dht22DataConfiguration : IEntityTypeConfiguration<Dht22Data> {
	public void Configure (EntityTypeBuilder<Dht22Data> builder) {
		builder.Property(b => b.JsonString)
			.HasColumnType("jsonb");

		builder.HasOne(data => data.Dht22Sensor)
			.WithMany(dh => dh.Data)
			.HasForeignKey(dht => dht.Id);

		builder.ToTable("dht_data", C.DbSchema);
	}
}