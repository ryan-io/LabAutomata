using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models;

public class LabJsonData : LabModel {
	/// <summary>
	/// Gets or sets the JSON string.
	/// </summary>
	[Required, MaxLength(500)]
	public string JsonString { get; init; }

	public int OwnerId { get; init; }

	public LabDataContainer DataContainer { get; init; }
}
