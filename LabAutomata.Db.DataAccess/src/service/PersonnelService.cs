using LabAutomata.Db.DataAccess.src.repository;
using LabAutomata.Db.models;

namespace LabAutomata.Db.DataAccess.src.service;

public class PersonnelService (IRepository<Personnel> repository) : Service<Personnel>(repository);