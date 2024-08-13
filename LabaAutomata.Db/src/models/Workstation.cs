using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {

	public class Workstation {
		public int Id { get; init; }

		[Required, MaxLength(75)] public required string Name { get; init; }

		[Required] public required int StationNumber { get; init; }

		[MaxLength(500)] public string? Description { get; init; }

		[Required] public required DateTime Created { get; init; } = DateTime.UtcNow;

		public Location? Location { get; init; }

		public ICollection<WorkstationType> Types { get; init; } = new List<WorkstationType>();

		public ICollection<Equipment> Equipment { get; init; } = new List<Equipment>();

		public ICollection<Test> Tests { get; init; } = new List<Test>();
	}
}