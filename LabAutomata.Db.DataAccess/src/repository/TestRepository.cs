using LabAutomata.Db.common;
using LabAutomata.Db.models;

namespace LabAutomata.Db.DataAccess.src.repository;

/// <summary>
/// Represents a repository for managing Test entities in the database.
/// </summary>
public class TestRepository (ILabPostgreSqlDbContext dbCtx)
	: Repository<Test>(dbCtx, dbCtx.Test);