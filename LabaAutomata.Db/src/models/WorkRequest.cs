using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {
	public class WorkRequest {
		public int Id { get; set; }

		[Required, MaxLength(100)]
		public required string Name { get; set; }

		[Required] public required int RequestId { get; set; }

		[Required, MaxLength(100)] public required string Program { get; set; }

		[MaxLength(1000)]
		public string? Description { get; set; } = string.Empty;

		public DateTime? Started { get; set; }

		public DateTime? Finished { get; set; }

		public ICollection<Test> Tests { get; set; } = new List<Test>();
	}
}