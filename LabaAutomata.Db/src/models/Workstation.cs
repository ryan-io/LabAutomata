//using System.ComponentModel.DataAnnotations;

//namespace LabAutomata.Db.models {

//	public class Workstation {

//		[Required, MaxLength(75)] public string Name { get; init; } = "";

//		public int StationNumber { get; init; }

//		public int LocationId { get; init; }

//		public Location? Location { get; init; }

//		public ICollection<WorkstationType> Types { get; init; } = new List<WorkstationType>();
//		public ICollection<Equipment> Equipment { get; init; } = new List<Equipment>();

//		public ICollection<Test> Tests { get; set; } = new List<Test>();

//		[MaxLength(500)]
//		public string? Description { get; init; }

//	}
//}