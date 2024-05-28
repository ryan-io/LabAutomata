using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {
    public class Location : LabModel {
        [Required, MaxLength(150)]
        public string Name { get; set; }

        [Required] public string Address { get; set; }

        [Required] public string City { get; set; }

        [Required] public string State { get; set; }
        [Required] public string Country { get; set; }
    }
}