using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {

	public class Personnel {
		public int Id { get; init; }

		[Required]
		public required string FirstName { get; init; }

		[Required]
		public required string LastName { get; init; }

		[EmailAddress]
		public string? Email { get; init; }

		public Location? Location { get; init; }
	}
}