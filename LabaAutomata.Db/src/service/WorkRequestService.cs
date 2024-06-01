using LabAutomata.Db.models;
using LabAutomata.Db.repository;

namespace LabAutomata.Db.service;

public class WorkRequestService (IRepository<WorkRequest> repository) : Service<WorkRequest>(repository);