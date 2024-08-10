using LabAutomata.Db.common;
using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabAutomata.Db.configurations;
internal class TestTypeConfiguration : IEntityTypeConfiguration<TestType> {

	public void Configure (EntityTypeBuilder<TestType> builder) {
		builder.ToTable("test_type", C.DbSchema);
	}

}