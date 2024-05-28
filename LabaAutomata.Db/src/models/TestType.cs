using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {
    public class TestType : LabModel {
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int BitId { get; set; }

        //    SteadyStateTemperature = 1 << 0,
        //    SteadyStateHumidity = 1 << 1,
        //    SteadyStateHumidity = 1 << 2,
        //    ThermalShock = 1 << 3,
        //    PowerTemperatureCycling = 1 << 4,
        //    CyclicHumidity = 1 << 5,
        //    ChemicalCorrosion = 1 << 6,
        //    FreeFall = 1 << 7,
        //    Immersion = 1 << 8,
        //    SaltFog = 1 << 9,
        //    SaltSpray = 1 << 10,
        //    HighPressureWaterSpray = 1 << 11,
        //    Seal = 1 << 12
    }
}
