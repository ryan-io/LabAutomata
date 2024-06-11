using LabAutomata.Db.models;
using LabAutomata.Db.repository;

namespace LabAutomata.Db.service;

public class DhtJsonDataService (IRepository<DhtJsonData> repository) : Service<DhtJsonData>(repository);