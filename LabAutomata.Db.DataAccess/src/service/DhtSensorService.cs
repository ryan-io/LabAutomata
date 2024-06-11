using LabAutomata.Db.DataAccess.src.repository;
using LabAutomata.Db.models;

namespace LabAutomata.Db.DataAccess.src.service;

public class DhtSensorService (IRepository<DhtSensor> repository) : Service<DhtSensor>(repository);