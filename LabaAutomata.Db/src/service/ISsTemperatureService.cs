using ErrorOr;
using LabAutomata.Db.models;

namespace LabAutomata.Db.service;

/// <summary>
/// Interface for the Steady State Temperature Service.
/// </summary>
public interface ISsTemperatureService {
    /// <summary>
    /// Creates a SteadyStateTemperatureTest.
    /// </summary>
    /// <param name="test">The SteadyStateTemperatureTest to create.</param>
    /// <param name="ct">The cancellation token (optional).</param>
    /// <returns>An ErrorOr result indicating success or failure, with the Created object if successful.</returns>
    Task<ErrorOr<Created>> CreateSsTempTest (SteadyStateTemperatureTest test, CancellationToken ct = default);

    /// <summary>
    /// Retrieves a SteadyStateTemperatureTest by its ID.
    /// </summary>
    /// <param name="instanceId">The ID of the SteadyStateTemperatureTest to retrieve.</param>
    /// <param name="ct">The cancellation token (optional).</param>
    /// <returns>An ErrorOr result indicating success or failure, with the SteadyStateTemperatureTest if successful.</returns>
    Task<ErrorOr<SteadyStateTemperatureTest>> GetSsTempTest (int instanceId, CancellationToken ct = default);

    /// <summary>
    /// Updates or inserts a SteadyStateTemperatureTest.
    /// </summary>
    /// <param name="instanceId">The ID of the SteadyStateTemperatureTest to update or insert.</param>
    /// <param name="test">The SteadyStateTemperatureTest to update or insert.</param>
    /// <param name="ct">The cancellation token (optional).</param>
    /// <returns>An ErrorOr result indicating success or failure, with the Updated object if successful.</returns>
    Task<ErrorOr<Updated>> UpsertSsTempTest (int instanceId, SteadyStateTemperatureTest test, CancellationToken ct = default);

    /// <summary>
    /// Deletes a SteadyStateTemperatureTest.
    /// </summary>
    /// <param name="instanceId">The instance id of the test to delete.</param>
    /// <param name="ct">The cancellation token (optional).</param>
    /// <returns>An ErrorOr result indicating success or failure, with the Deleted object if successful.</returns>
    Task<ErrorOr<Deleted>> DeleteSsTempTest (int instanceId, CancellationToken ct = default);
}
