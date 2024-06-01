using LabAutomata.Db.models;
using LabAutomata.Db.repository;

namespace LabAutomata.Db.service;

public class WorkstationService (IRepository<Workstation> repository) : Service<Workstation>(repository);