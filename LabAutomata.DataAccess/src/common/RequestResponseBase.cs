namespace LabAutomata.DataAccess.common {
	public record RequestResponseBase {
		public DateTime DateModifiedUtc { get; } = DateTime.UtcNow;
	}
}
