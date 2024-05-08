namespace LabAutomata.Library.models {
    public class Test : LabModel {
        public string Name { get; set; }

        public int InstanceId { get; set; }

        public DateTime Started { get; set; } = DateTime.UtcNow;

        public DateTime Ended { get; set; }

        protected Test (Test test) {
            Name = test.Name;
            InstanceId = test.InstanceId;
            Started = test.Started;
            Ended = test.Ended;
        }

        protected Test (string name, int instanceId) {
            Name = name;
            InstanceId = instanceId;
        }
    }
}
