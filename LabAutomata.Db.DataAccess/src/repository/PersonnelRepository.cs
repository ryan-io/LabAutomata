using LabAutomata.Db.common;
using LabAutomata.Db.models;

namespace LabAutomata.Db.DataAccess.src.repository;

/// <summary>
/// Represents a repository for managing Personnel entities in the database.
/// </summary>
public class PersonnelRepository (ILabPostgreSqlDbContext dbCtx)
	: Repository<Personnel>(dbCtx, dbCtx.Personnels);