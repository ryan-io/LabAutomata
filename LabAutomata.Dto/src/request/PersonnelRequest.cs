namespace LabAutomata.Dto.request {
	public record PersonnelRequest (
		string FirstName,
		string LastName,
		string Email,
		string PhoneNumber,
		int? LocationId) {
	}
}
