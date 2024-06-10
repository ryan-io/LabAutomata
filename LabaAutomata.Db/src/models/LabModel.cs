using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabAutomata.Db.models {

	public abstract class LabModel {

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; init; }

		public DateTime Created { get; init; } = DateTime.UtcNow;
	}
}