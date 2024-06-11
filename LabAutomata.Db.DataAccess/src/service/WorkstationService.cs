using LabAutomata.Db.DataAccess.src.repository;
using LabAutomata.Db.models;

namespace LabAutomata.Db.DataAccess.src.service;

public class WorkstationService (IRepository<Workstation> repository) : Service<Workstation>(repository);