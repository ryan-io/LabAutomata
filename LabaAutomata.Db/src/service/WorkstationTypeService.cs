using LabAutomata.Db.models;
using LabAutomata.Db.repository;

namespace LabAutomata.Db.service;

public class WorkstationTypeService (IRepository<WorkstationType> repository) : Service<WorkstationType>(repository);