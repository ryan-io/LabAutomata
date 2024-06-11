using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models;

public class DhtJsonData : LabModel {
	/// <summary>
	/// Gets or sets the JSON string.
	/// </summary>
	[Required, MaxLength(500)]
	public string JsonString { get; init; }

	public int DhtSensorId { get; init; }

	public DhtSensor DhtSensor { get; init; }
}
