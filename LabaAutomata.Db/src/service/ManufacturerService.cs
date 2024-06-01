using LabAutomata.Db.models;
using LabAutomata.Db.repository;

namespace LabAutomata.Db.service;

public class ManufacturerService (IRepository<Manufacturer> repository) : Service<Manufacturer>(repository);