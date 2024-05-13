namespace LabAutomata.Db.models;

public class SteadyStateTemperatureTest : Test {
    public ICollection<TemperaturePoint> Data { get; init; } = new HashSet<TemperaturePoint>();

    internal SteadyStateTemperatureTest (int instanceId)
        : base("Steady State Temperature", instanceId) { }

    internal SteadyStateTemperatureTest (int id, int instanceId)
        : base("Steady State Temperature", instanceId) { Id = id; }
}