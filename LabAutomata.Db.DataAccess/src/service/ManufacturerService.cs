using LabAutomata.Db.DataAccess.src.repository;
using LabAutomata.Db.models;

namespace LabAutomata.Db.DataAccess.src.service;

public class ManufacturerService (IRepository<Manufacturer> repository) : Service<Manufacturer>(repository);