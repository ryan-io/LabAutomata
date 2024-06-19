namespace LabAutomata.Dto.request {
	public record EquipmentRequest (
		string Name,
		string SerialNumber,
		string Description,
		int DhtSensorId) {
	}
}
