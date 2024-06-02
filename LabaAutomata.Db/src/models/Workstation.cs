using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {
	public class Workstation : LabModel {
		[Required, MaxLength(75)]
		public string Name { get; init; }

		public int StationNumber { get; init; }

		public int LocationId { get; init; }

		public Location Location { get; init; }

		public ICollection<WorkstationType> Types { get; init; }
		public ICollection<Equipment> Equipment { get; init; }

		public ICollection<Test> Tests { get; set; }

		[MaxLength(500)]
		public string Description { get; init; }
	}
}
