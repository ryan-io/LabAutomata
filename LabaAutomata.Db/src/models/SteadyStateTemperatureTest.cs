namespace LabAutomata.Db.models;

public class SteadyStateTemperatureTest : Test {
    public ICollection<TemperaturePoint> Data { get; set; }

    public static SteadyStateTemperatureTest New (int instanceId) {
        return new SteadyStateTemperatureTest(instanceId);
    }

    protected SteadyStateTemperatureTest (int instanceId)
        : base("Steady State Temperature", instanceId) {
        Data = new HashSet<TemperaturePoint>();
    }
}