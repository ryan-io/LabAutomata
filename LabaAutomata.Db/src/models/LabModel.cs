namespace LabAutomata.Db.models {
    public abstract class LabModel {
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}
