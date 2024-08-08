using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {

	public class WorkstationType {
		public int Id { get; set; }

		[Required, MaxLength(50)]
		public required string Name { get; set; }
	}
}