using LabAutomata.Db.models;

namespace LabAutomata.Dto.response {
	public record DhtJsonDataResponse (
		int Id,
		string JsonString,
		int DhtSensorId,
		Dht22Sensor? DhtSensor) {
	}
}
