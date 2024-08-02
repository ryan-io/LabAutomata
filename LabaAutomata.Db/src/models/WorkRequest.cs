//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace LabAutomata.Db.models {
//	[Table("work_requests")]
//	public class WorkRequest {
//		public int WrId { get; init; }

//		[Required, MaxLength(100)]
//		public string? Name { get; init; } = string.Empty;

//		[Required, MaxLength(100)] public string? Program { get; init; } = string.Empty;

//		[MaxLength(1000)]
//		public string? Description { get; init; } = string.Empty;

//		public Manufacturer Manufacturer { get; init; }

//		public int ManufacturerId { get; init; }

//		public DateTime? Started { get; init; }
//		public DateTime? Finished { get; init; }

//		// navigation property for tests
//		public ICollection<Test>? Tests { get; init; }
//	}
//}