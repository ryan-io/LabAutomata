using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {

	public class Personnel {
		public int Id { get; set; }

		[Required, MaxLength(50)]
		public required string FirstName { get; set; }

		[Required, MaxLength(50)]
		public required string LastName { get; set; }

		[MaxLength(125)]
		public string? Email { get; set; }

		public int LocationId { get; set; }

		public Location? Location { get; set; }
	}
}