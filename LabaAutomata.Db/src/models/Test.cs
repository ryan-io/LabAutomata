using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {
	public class Test {
		public int Id { get; set; }

		[Required] public int InstanceId { get; init; }

		[Required, MaxLength(100)] public string? Name { get; init; }

		[Required] public required WorkRequest WorkRequest { get; init; }

		[Required] public required TestType Type { get; init; }

		public Personnel? Operator { get; init; }

		public Location? Location { get; init; }

		public DateTime? Started { get; init; }

		public DateTime? Ended { get; init; }


		//TODO: redefine the workstation collection for Test
		//public ICollection<Workstation>? Workstations { get; set; }
	}
}