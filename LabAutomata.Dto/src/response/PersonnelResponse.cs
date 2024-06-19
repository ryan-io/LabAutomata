namespace LabAutomata.Dto.response {
	public record PersonnelResponse (
		int Id,
		string FirstName,
		string LastName,
		string Email,
		string PhoneNumber,
		int? LocationId,
		LocationResponse? Location) {
	}
}
