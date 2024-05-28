using LabAutomata.Db.common;
using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {
    public class Test : LabModel {
        [Required, MaxLength(100)] public string? Name { get; set; }

        [Required]
        public int WrId { get; set; }

        public WorkRequest WorkRequest { get; set; }

        [Required]
        public int InstanceId { get; set; }

        public TestType Type { get; set; }

        public DateTime? Started { get; set; } = DateTime.UtcNow;

        public DateTime? Ended { get; set; }

        protected Test () {
            Name = "unnamed";
        }

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
