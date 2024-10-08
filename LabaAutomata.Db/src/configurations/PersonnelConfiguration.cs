﻿using LabAutomata.Db.common;
using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabAutomata.Db.configurations;

internal class PersonnelConfiguration : IEntityTypeConfiguration<Personnel> {

	public void Configure (EntityTypeBuilder<Personnel> builder) {
		builder.HasOne(p => p.Location);

		builder.ToTable("personnel", C.DbSchema);
	}
}