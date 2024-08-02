//using System.ComponentModel.DataAnnotations;

//namespace LabAutomata.Db.models {

//	public class Test {
//		[Required, MaxLength(100)] public string? Name { get; init; }

//		[Required]
//		public int WrId { get; init; }

//		public WorkRequest? WorkRequest { get; init; }

//		public ICollection<Workstation>? Workstations { get; set; }

//		[Required]
//		public int InstanceId { get; init; }

//		[Required]
//		public int TypeId { get; init; }

//		[Required]
//		public TestType? Type { get; init; }

//		[Required]
//		public int LocationId { get; init; }

//		public int OperatorId { get; init; }

//		public Personnel? Operator { get; init; }

//		public Location? Location { get; init; }

//		public DateTime? Started { get; init; } = DateTime.UtcNow;

//		public DateTime? Ended { get; init; }

//		public Test () {
//			Name = "unnamed";
//		}

//		public Test (Test test) {
//			Name = test.Name;
//			InstanceId = test.InstanceId;
//			Started = test.Started;
//			Ended = test.Ended;
//			Type = test.Type;
//		}

//		public Test (int id, Test test) {
//			Name = test.Name;
//			InstanceId = test.InstanceId;
//			Started = test.Started;
//			Ended = test.Ended;
//			Type = test.Type;
//		}

//		public Test (string name, int instanceId) {
//			Name = name;
//			InstanceId = instanceId;
//		}
//	}
//}