namespace LabAutomata.Db.models {
    public abstract class LabModel {
        public int Id { get; init; }
        public DateTime Created { get; init; } = DateTime.UtcNow;
    }
}
