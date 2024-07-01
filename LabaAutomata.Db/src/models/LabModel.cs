using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {

	public abstract class LabModel {

		[Key]
		public int Id { get; init; }

		public DateTime Created { get; init; } = DateTime.UtcNow;
	}
}