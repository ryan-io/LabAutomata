using LabAutomata.Db.DataAccess.src.repository;
using LabAutomata.Db.models;

namespace LabAutomata.Db.DataAccess.src.service;

public class DhtJsonDataService (IRepository<DhtJsonData> repository) : Service<DhtJsonData>(repository);