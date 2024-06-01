using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {
    public class TestType : LabModel {
        [Required, MaxLength(50)]
        public string Name { get; init; }

        internal const int SteadyStateTemperature = 1 << 0;
        internal const int SteadyStateHumidity = 1 << 1;
        internal const int ThermalShock = 1 << 2;
        internal const int PowerTemperatureCycling = 1 << 3;
        internal const int CyclicHumidity = 1 << 4;
        internal const int ChemicalCorrosion = 1 << 5;
        internal const int FreeFall = 1 << 6;
        internal const int Immersion = 1 << 7;
        internal const int SaltFog = 1 << 8;
        internal const int SaltSpray = 1 << 9;
        internal const int HighPressureWaterSpray = 1 << 10;
        internal const int Seal = 1 << 11;
        internal const int Vibration = 1 << 12;
        internal const int MechanicalShock = 1 << 13;
    }
}
