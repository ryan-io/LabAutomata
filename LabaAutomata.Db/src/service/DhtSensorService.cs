using LabAutomata.Db.models;
using LabAutomata.Db.repository;

namespace LabAutomata.Db.service;

public class DhtSensorService (IRepository<DhtSensor> repository) : Service<DhtSensor>(repository);