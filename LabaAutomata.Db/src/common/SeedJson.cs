using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LabAutomata.Db.models;
using Newtonsoft.Json;

namespace LabAutomata.Db.common {
    public class SeedJson: LabModel {
        [Column(TypeName = "jsonb")]
        [Required]
        public string SerializedData { get; set; } = string.Empty;
    }

    [Serializable]
    public class Seed
    {
        public int WorkRequestCurrent { get; set; }

        public int TestInstanceCurrent { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
