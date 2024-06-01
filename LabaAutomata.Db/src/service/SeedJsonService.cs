using LabAutomata.Db.models;
using LabAutomata.Db.repository;

namespace LabAutomata.Db.service;

public class SeedJsonService (IRepository<SeedJson> repository) : Service<SeedJson>(repository);