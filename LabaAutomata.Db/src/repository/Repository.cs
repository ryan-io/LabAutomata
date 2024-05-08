using LabAutomata.Library.src.models;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.Db.src.repository {
    public class TestRepository (DbSet<Test> set) : Repository<Test>(set) { }

    public abstract class Repository<T> (DbSet<T> set)
        where T : class {
        public T? Get () {
            return default;
        }

        bool Add (T entity) {
            return true;
        }

        bool Delete () {
            return false;
        }
    }
}
