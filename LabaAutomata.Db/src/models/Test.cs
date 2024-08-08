using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {
	public class Test {
		public int Id { get; init; }

		[Required] public int InstanceId { get; init; }

		[Required, MaxLength(100)] public string? Name { get; init; }

		//[Required] public required int WorkRequestId { get; init; }
		[Required] public required WorkRequest WorkRequest { get; init; }

		//[Required] public required int TypeId { get; init; }
		[Required] public required TestType Type { get; init; }

		//public int PersonnelId { get; init; }

		public Personnel? Operator { get; init; }
		//public int LocationId { get; init; }

		public Location? Location { get; init; }

		public DateTime? Started { get; init; }

		public DateTime? Ended { get; init; }

		public ICollection<Workstation>? Workstations { get; init; } = new List<Workstation>();
	}
}