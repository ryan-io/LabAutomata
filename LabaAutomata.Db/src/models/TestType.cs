using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models;

public class TestType {
	public int Id { get; set; }

	[Required, MaxLength(50)] public required string Name { get; set; }
}