using LabAutomata.Db.models;

namespace LabAutomata.Db.repository;

public interface IRepository<T> where T : LabModel {
    Task Create (T entity);
    T? Get (int id);
    Task Update (T entity);
    Task Delete (T entity);
}