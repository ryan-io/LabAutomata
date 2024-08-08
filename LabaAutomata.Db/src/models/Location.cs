using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {

	public class Location {
		public int Id { get; set; }

		[Required, MaxLength(150)]
		public required string Name { get; set; }

		[Required, MaxLength(80)] public required string Country { get; set; }

		[Required, MaxLength(80)] public required string City { get; set; }

		[Required, MaxLength(50)] public required string State { get; set; }

		[MaxLength(175)] public string? Address { get; set; }
	}
}