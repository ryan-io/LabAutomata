using LabAutomata.Db.models;
using LabAutomata.Db.repository;

namespace LabAutomata.Db.service;

public class LocationService (IRepository<Location> repository) : Service<Location>(repository);