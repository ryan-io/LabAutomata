using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {

	public class Personnel {
		public int Id { get; init; }

		[Required, MaxLength(50)]
		public required string FirstName { get; init; }

		[Required, MaxLength(50)]
		public required string LastName { get; init; }

		[MaxLength(125)]
		public string? Email { get; init; }

		//public int LocationId { get; init; }

		public Location? Location { get; init; }
	}
}