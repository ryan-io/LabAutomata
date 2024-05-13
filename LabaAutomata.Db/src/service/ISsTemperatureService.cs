using ErrorOr;
using LabAutomata.Db.models;

namespace LabAutomata.Db.service;

public interface ISsTemperatureService {
    Task<ErrorOr<Created>> CreateSsTempTest (SteadyStateTemperatureTest test, CancellationToken ct = default);
    Task<ErrorOr<SteadyStateTemperatureTest>> GetSsTempTest (int id);
    Task<ErrorOr<Updated>> UpsertSsTempTest (SteadyStateTemperatureTest test, CancellationToken ct = default);
    Task<ErrorOr<Deleted>> DeleteSsTempTest (SteadyStateTemperatureTest test, CancellationToken ct = default);
}