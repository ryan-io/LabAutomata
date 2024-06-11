using LabAutomata.Db.DataAccess.src.repository;
using LabAutomata.Db.models;

namespace LabAutomata.Db.DataAccess.src.service;

public class TemperaturePointService (IRepository<TemperaturePoint> repository) : Service<TemperaturePoint>(repository);