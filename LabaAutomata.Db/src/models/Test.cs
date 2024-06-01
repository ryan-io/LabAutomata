﻿using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {
    public class Test : LabModel {
        [Required, MaxLength(100)] public string? Name { get; set; }

        [Required]
        public int WrId { get; set; }

        public WorkRequest? WorkRequest { get; set; }

        public ICollection<Workstation>? Workstations { get; set; }

        [Required]
        public int InstanceId { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        public TestType? Type { get; set; }

        [Required]
        public int LocationId { get; set; }

        public int OperatorId { get; set; }

        public Personnel? Operator { get; set; }

        public Location? Location { get; set; }

        public DateTime? Started { get; set; } = DateTime.UtcNow;

        public DateTime? Ended { get; set; }

        public Test () {
            Name = "unnamed";
        }

        public Test (Test test) {
            Name = test.Name;
            InstanceId = test.InstanceId;
            Started = test.Started;
            Ended = test.Ended;
            Type = test.Type;
        }

        public Test (int id, Test test) {
            Id = id;
            Name = test.Name;
            InstanceId = test.InstanceId;
            Started = test.Started;
            Ended = test.Ended;
            Type = test.Type;
        }

        public Test (string name, int instanceId) {
            Name = name;
            InstanceId = instanceId;
        }
    }
}
