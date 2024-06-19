namespace LabAutomata.Dto.response {
	public record EquipmentResponse (
		int Id,
		string Name,
		string SerialNumber,
		string Description,
		int DhtSensorId,
		DhtSensorResponse DhtSensor) {
	}
}
