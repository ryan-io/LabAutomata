using System.ComponentModel.DataAnnotations;

namespace LabAutomata.Db.models {
    public class WorkstationType : LabModel {
        [Required, MaxLength(50)]
<<<<<<< HEAD
        public string Name { get; set; }
=======
        public string Name { get; init; }
>>>>>>> 28bfd48 (added services for the remaining db models. fixed fixed domain models that were failing unit tests. created factory methods for tests and test types. removed a task.run from the application's entry point command.)

        public static int ThermalShock = 1 << 0;
        public static int PowerTemperatureCycle = 1 << 1;
        public static int Salt = 1 << 2;
        public static int Corrosion = 1 << 3;
        public static int Drop = 1 << 4;
        public static int WaterSpray = 1 << 5;
        public static int Water = 1 << 6;
        public static int Vibration = 1 << 7;
        public static int Humidity = 1 << 8;
        public static int Temperature = 1 << 9;
    }
}
