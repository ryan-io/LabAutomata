namespace LabAutomata.Db.models;

public class SteadyStateTemperatureTest : Test {
    public ICollection<TemperaturePoint> Data { get; init; } = new HashSet<TemperaturePoint>();

    internal SteadyStateTemperatureTest (int instanceId)
        : base(TestName, instanceId) { }

    internal SteadyStateTemperatureTest (int id, int instanceId)
        : base(TestName, instanceId) { Id = id; }

    internal SteadyStateTemperatureTest (int cloneId, SteadyStateTemperatureTest clone) : base(TestName, clone.InstanceId) {
        Id = cloneId;
        Data = clone.Data;
        Started = clone.Started;
        Ended = clone.Ended;
    }

    private const string TestName = "Steady State Temperature";
}