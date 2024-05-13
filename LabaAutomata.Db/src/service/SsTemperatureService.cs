using ErrorOr;
using LabAutomata.Db.common;
using LabAutomata.Db.models;
using LabAutomata.Db.repository;

namespace LabAutomata.Db.service {
    /// <summary>
    /// Represents a service for managing steady state temperature tests.
    /// </summary>
    public class SsTemperatureService (IRepository<SteadyStateTemperatureTest> repository) : ISsTemperatureService {
        /// <summary>
        /// Creates a new steady state temperature test.
        /// </summary>
        /// <param name="test">The steady state temperature test to create.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>An error or the created result.</returns>
        public async Task<ErrorOr<Created>> CreateSsTempTest (SteadyStateTemperatureTest test, CancellationToken ct = default) {
            var result = await repository.Create(test, ct);

            if (result) {
                return new Created();
            }
            else {
                return Errors.Db.CouldNotCreate(EntryReturned0Code, EntryReturned0Msg);
            }
        }

        /// <summary>
        /// Retrieves a steady state temperature test by its ID.
        /// </summary>
        /// <param name="instanceId">The ID of the steady state temperature test.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>An error or the retrieved steady state temperature test.</returns>
        public async Task<ErrorOr<SteadyStateTemperatureTest>> GetSsTempTest (int instanceId, CancellationToken ct = default) {
            var state = await repository.Get(instanceId, ct);

            if (state == null) {
                return Errors.Db.CouldNotGet(IdCouldNotBeFoundCode, IdCouldNotBeFoundMsg);
            }
            else {
                return state;
            }
        }

        /// <summary>
        /// Updates or inserts a steady state temperature test.
        /// </summary>
        /// <param name="instanceId">The ID of the steady state temperature test.</param>
        /// <param name="test">The steady state temperature test to update or insert.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>An error or the updated result.</returns>
        public async Task<ErrorOr<Updated>> UpsertSsTempTest (int instanceId, SteadyStateTemperatureTest test, CancellationToken ct = default) {
            var state = await repository.Upsert(instanceId, test, ct);

            if (state)
                return new Updated();
            return Errors.Db.CouldNotUpsert(CouldNotUpsertGenericCode, CouldNotUpsertGenericMsg);
        }

        /// <summary>
        /// Deletes a steady state temperature test.
        /// </summary>
        /// <param name="instanceId">The instance if of the steady state temperature test to delete.</param>
        /// <param name="ct">The cancellation token.</param>
        /// <returns>An error or the deleted result.</returns>
        public async Task<ErrorOr<Deleted>> DeleteSsTempTest (int instanceId, CancellationToken ct = default) {
            var state = await repository.Delete(instanceId, ct);

            if (state) {
                return new Deleted();
            }
            else {
                return Errors.Db.CouldNotUpsert(CouldNotDeleteGenericCode, CouldNotDeleteGenericMsg);
            }
        }

        private const string EntryReturned0Code = "SsTempTest.EntryReturned0";
        private const string EntryReturned0Msg = "Entry returned 0; this needs to be debugged.";

        private const string IdCouldNotBeFoundCode = "SsTempTest.IdCouldNotBeFoundCode";
        private const string IdCouldNotBeFoundMsg = "Could not find an entity with the provided id.";

        private const string CouldNotUpsertGenericCode = "SsTempTest.CouldNotUpsertGenericCode";
        private const string CouldNotUpsertGenericMsg = "Could not upsert the entity.";

        private const string CouldNotDeleteGenericCode = "SsTempTest.CouldNotDeleteGenericCode";
        private const string CouldNotDeleteGenericMsg = "Could not delete the entity.";
    }
}