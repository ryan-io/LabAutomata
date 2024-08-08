using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {
	public class Test {
		public int Id { get; set; }

		[Required] public int InstanceId { get; set; }

		[Required, MaxLength(100)] public string? Name { get; set; }

		[Required] public required int WorkRequestId { get; set; }
		[Required] public required WorkRequest WorkRequest { get; set; }

		[Required] public required int TypeId { get; set; }
		[Required] public required TestType Type { get; set; }

		public int PersonnelId { get; set; }

		public Personnel? Operator { get; set; }
		public int LocationId { get; set; }

		public Location? Location { get; set; }

		public DateTime? Started { get; set; }

		public DateTime? Ended { get; set; }

		public ICollection<Workstation>? Workstations { get; set; } = new List<Workstation>();
	}
}