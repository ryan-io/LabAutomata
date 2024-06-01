using LabAutomata.Db.models;
using LabAutomata.Db.repository;

namespace LabAutomata.Db.service;

public class TestTypeService (IRepository<TestType> repository) : Service<TestType>(repository);