using LabAutomata.Db.common;
using LabAutomata.Db.models;

namespace LabAutomata.Db.DataAccess.src.repository;

/// <summary>
/// Represents a repository for managing TestType entities in the database.
/// </summary>
public class TestTypeRepository (ILabPostgreSqlDbContext dbCtx)
	: Repository<TestType>(dbCtx, dbCtx.TestType);