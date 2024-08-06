using LabAutomata.Db.common;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.service;

public abstract class ServiceBase {
	protected ServiceBase (IDbContextFactory<PostgreSqlDbContext> dbContextFactory) {
		DbContextFactory = dbContextFactory;
	}

	protected IDbContextFactory<PostgreSqlDbContext> DbContextFactory { get; }

	protected abstract string Name { get; }
}