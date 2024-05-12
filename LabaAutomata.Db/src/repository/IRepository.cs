using LabAutomata.Db.models;

namespace LabAutomata.Db.repository;

public interface IRepository<T> where T : LabModel {
    void Create (T entity);
    T Get (int id);
    void Update (T entity);
    void Delete (T entity);
}