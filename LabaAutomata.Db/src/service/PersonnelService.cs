using LabAutomata.Db.models;
using LabAutomata.Db.repository;

namespace LabAutomata.Db.service;

public class PersonnelService (IRepository<Personnel> repository) : Service<Personnel>(repository);