using LabAutomata.Db.repository;
using Newtonsoft.Json;

namespace LabAutomata.Db.common {
    public class WrIdGenerator {
        public async Task<int> GetNext (CancellationToken token = default) {
            var json = await _repository.Get(DbId, token);
            var seed = JsonConvert.DeserializeObject(json!.SerializedData) as Seed;
            var copy = seed!.WorkRequestCurrent;
            seed.WorkRequestCurrent++;
            var newJson = JsonConvert.SerializeObject(seed);
            json.SerializedData = newJson;
            await _repository.Upsert(json, ct: token);

            return copy;
        }

        public WrIdGenerator (IRepository<SeedJson> repository) {
            _repository = repository;
        }

        readonly IRepository<SeedJson> _repository;
        private const int DbId = 1;
    }
}