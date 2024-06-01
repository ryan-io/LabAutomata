namespace LabAutomata.Db.models {
    public class TemperaturePoint : LabModel {
        public int InstanceId { get; private set; }
        public float Value { get; private set; }
        public DateTime Timestamp { get; private set; }
        public TemperatureUnit Unit { get; private set; }
    }

}
