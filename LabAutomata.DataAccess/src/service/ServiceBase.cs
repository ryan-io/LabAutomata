using LabAutomata.Db.common;

namespace LabAutomata.DataAccess.service;

public abstract class ServiceBase {

	protected ServiceBase (PostgreSqlDbContext dbContext) => DbContext = dbContext;

	protected PostgreSqlDbContext DbContext { get; }
}