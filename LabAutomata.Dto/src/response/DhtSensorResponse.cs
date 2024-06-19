namespace LabAutomata.Dto.response {
	public record DhtSensorResponse (
		int Id,
		string Name,
		string Location,
		double Temperature,
		double Humidity,
		string Description) {
	}
}
