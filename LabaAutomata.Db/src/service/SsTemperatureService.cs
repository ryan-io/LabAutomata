using ErrorOr;
using LabAutomata.Db.common;
using LabAutomata.Db.models;
using LabAutomata.Db.repository;

namespace LabAutomata.Db.service {
    public class SsTemperatureService (IRepository<SteadyStateTemperatureTest> repository) : ISsTemperatureService {
        public async Task<ErrorOr<Created>> CreateSsTempTest (SteadyStateTemperatureTest test, CancellationToken ct = default) {
            var result = await repository.Create(test, ct);

            if (result) return new Created(); // TODO: should be more precise - maybe?
            return Errors.Db.CouldNotCreate(EntryReturned0Code, EntryReturned0Msg);
        }

        public async Task<ErrorOr<SteadyStateTemperatureTest>> GetSsTempTest (int id) {
            var state = await repository.Get(id);

            if (state == null)
                return Errors.Db.CouldNotGet(IdCouldNotBeFoundCode, IdCouldNotBeFoundMsg);
            return state;
        }

        public async Task<ErrorOr<Updated>> UpsertSsTempTest (SteadyStateTemperatureTest test, CancellationToken ct = default) {
            var state = await repository.Upsert(test, ct);
            return state
                ? new Updated()
                : Errors.Db.CouldNotUpsert(CouldNotUpsertGenericCode, CouldNotUpsertGenericMsg);
        }

        public async Task<ErrorOr<Deleted>> DeleteSsTempTest (SteadyStateTemperatureTest test, CancellationToken ct = default) {
            var state = await repository.Delete(test, ct);

            return state
                ? new Deleted()
                : Errors.Db.CouldNotUpsert(CouldNotDeleteGenericCode, CouldNotDeleteGenericMsg);
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