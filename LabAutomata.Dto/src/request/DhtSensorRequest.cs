namespace LabAutomata.Dto.request {
	public record DhtSensorRequest (
		string Name,
		string Location,
		double Temperature,
		double Humidity,
		string Description) {
	}
}
