using LabAutomata.Db.models;

namespace LabAutomata.Db.service;

public interface ISsTemperatureService {
    void CreateSsTempTest (SteadyStateTemperatureTest test);
    SteadyStateTemperatureTest GetSsTempTest (int id);
    void UpdateSsTempTest (SteadyStateTemperatureTest test);
    void DeleteSsTempTest (SteadyStateTemperatureTest test);
}