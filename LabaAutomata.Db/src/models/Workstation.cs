using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {
    public class Workstation : LabModel {
        [Required, MaxLength(75)]
        public string Name { get; set; }

        public int StationNumber { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }

        public ICollection<WorkstationType> Types { get; set; }

        public ICollection<Test> Tests { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
    }
}
