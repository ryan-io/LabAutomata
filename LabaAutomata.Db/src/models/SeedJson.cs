using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabAutomata.Db.models {

	public class SeedJson : LabModel {

		[Column(TypeName = "jsonb")]
		[Required, MaxLength(300)]
		public string SerializedData { get; set; } = string.Empty;
	}
}