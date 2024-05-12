using LabAutomata.Db.models;
using LabAutomata.Db.repository;

namespace LabAutomata.Db.service {
    public class SsTemperatureService (IRepository<SteadyStateTemperatureTest> repository) : ISsTemperatureService {
        public void CreateSsTempTest (SteadyStateTemperatureTest test) {
            repository.Create(test);
        }

        public SteadyStateTemperatureTest GetSsTempTest (int id) {
            return repository.Get(id);
        }

        public void UpdateSsTempTest (SteadyStateTemperatureTest test) {
            repository.Update(test);
        }

        public void DeleteSsTempTest (SteadyStateTemperatureTest test) {
            repository.Delete(test);
        }
    }
}
