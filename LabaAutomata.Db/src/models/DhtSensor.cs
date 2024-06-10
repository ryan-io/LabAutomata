using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LabAutomata.Db.models;

[Table("dht_sensors")]
public class DhtSensor : LabDataContainer {
	/// <summary>
	/// Gets or sets the name of the sensor.
	/// </summary>
	[Required, MaxLength(100)]
	public string SensorName { get; init; }

}