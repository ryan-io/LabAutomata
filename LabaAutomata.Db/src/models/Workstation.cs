using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {

	public class Workstation {
		public int Id { get; set; }

		[Required, MaxLength(75)] public required string Name { get; set; }

		[Required] public required int StationNumber { get; set; }

		[MaxLength(500)] public string? Description { get; set; }

		[Required] public required DateTime Created { get; set; } = DateTime.UtcNow;

		public int LocationId { get; set; }
		public Location? Location { get; set; }

		public ICollection<WorkstationType> Types { get; set; } = new List<WorkstationType>();

		public ICollection<Equipment> Equipment { get; set; } = new List<Equipment>();

		public ICollection<Test> Tests { get; set; } = new List<Test>();
	}
}