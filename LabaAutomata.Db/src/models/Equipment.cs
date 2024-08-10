using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {

	public class Equipment {
		public int Id { get; init; }

		[Required, MaxLength(75)] public required string Name { get; init; }

		[Required] public required DateTime PurchaseDate { get; init; }
		[Required] public required DateTime CalibrationDate { get; init; }
		[Required] public required DateTime CalibrationDueDate { get; init; }
		[Required] public required Manufacturer Manufacturer { get; init; }

		public ICollection<Workstation> Workstations { get; init; } = new List<Workstation>();
	}
}