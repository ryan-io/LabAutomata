namespace LabAutomata.Db.models {
    public class TemperaturePoint : LabModel {
        public int InstanceId { get; set; }
        public float Value { get; set; }
        public DateTime Timestamp { get; set; }
        public TemperatureUnit Unit { get; set; }
    }

}
