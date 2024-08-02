using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {

	public class Location {
		public int Id { get; init; }

		[Required, MaxLength(150)]
		public required string Name { get; init; }

		[Required, MaxLength(80)] public required string Country { get; init; }

		[Required, MaxLength(80)] public required string City { get; init; }

		[Required, MaxLength(50)] public required string State { get; init; }

		[MaxLength(175)] public string? Address { get; init; }
	}
}