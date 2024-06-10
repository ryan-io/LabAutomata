using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {

	public class Personnel : LabModel {

		[Required]
		public string FirstName { get; init; } = string.Empty;

		[Required]
		public string LastName { get; init; } = string.Empty;

		[EmailAddress]
		public string? Email { get; init; }

		public int LocationId { get; init; }

		public Location Location { get; init; }
	}
}