using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabAutomata.Db.configurations;

internal class DhtJsonDataConfiguration : IEntityTypeConfiguration<DhtJsonData> {
	public void Configure (EntityTypeBuilder<DhtJsonData> builder) {
		builder.Property(b => b.JsonString)
			.HasColumnType("jsonb");
	}
}