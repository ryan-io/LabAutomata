using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {
	public class WorkRequest {
		public int Id { get; init; }

		[Required, MaxLength(100)]
		public required string Name { get; init; }

		//[Required] public required int RequestId { get; init; }

		[Required, MaxLength(100)] public required string Program { get; init; }

		[MaxLength(1000)]
		public string? Description { get; init; } = string.Empty;

		public DateTime? Started { get; init; }

		public DateTime? Finished { get; init; }

		public ICollection<Test> Tests { get; init; } = new List<Test>();
	}
}