using LabAutomata.Db.models;
using LabAutomata.Db.repository;

namespace LabAutomata.Db.service;

public class TestService (IRepository<Test> repository) : Service<Test>(repository);