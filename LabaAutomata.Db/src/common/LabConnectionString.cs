using LabAutomata.Db.src.abstraction;

namespace LabAutomata.Db.src.common {
    public class LabConnectionString : IConnectionString {
        public string Get => C.LAB_POSTGRES_DATABASE_CONNECTION;
    }
}
