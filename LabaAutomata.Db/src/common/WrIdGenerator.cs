using LabAutomata.Db.models;
using LabAutomata.Db.repository;

namespace LabAutomata.Db.common {
    public class WrIdGenerator {
        public async Task<int> GetNext () {
            var t = await _repository.GetAll();
            var max = t.Max(wr => wr.WrId);
            return ++max;
        }

        public WrIdGenerator (IRepository<WorkRequest> repository) {
            _repository = repository;
        }

        readonly IRepository<WorkRequest> _repository;
    }
}