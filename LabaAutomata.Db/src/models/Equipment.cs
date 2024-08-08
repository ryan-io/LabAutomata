using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {

	public class Equipment {
		public int Id { get; set; }

		[Required, MaxLength(75)] public required string Name { get; set; }

		[Required] public required DateTime PurchaseDate { get; set; }
		[Required] public required DateTime CalibrationDate { get; set; }
		[Required] public required DateTime CalibrationDueDate { get; set; }
		[Required] public required int ManufacturerId { get; set; }
		[Required] public required Manufacturer Manufacturer { get; set; }

		public ICollection<Workstation> Workstations { get; set; } = new List<Workstation>();
	}
}