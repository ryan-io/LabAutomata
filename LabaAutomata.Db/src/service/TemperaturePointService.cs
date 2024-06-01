using LabAutomata.Db.models;
using LabAutomata.Db.repository;

namespace LabAutomata.Db.service;

public class TemperaturePointService (IRepository<TemperaturePoint> repository) : Service<TemperaturePoint>(repository);