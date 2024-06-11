using LabAutomata.Db.DataAccess.src.repository;
using LabAutomata.Db.models;

namespace LabAutomata.Db.DataAccess.src.service;

public class WorkstationTypeService (IRepository<WorkstationType> repository) : Service<WorkstationType>(repository);