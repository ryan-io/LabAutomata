using LabAutomata.Db.common;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.unit_of_work {
	public abstract class UnitOfWork {
		public UnitOfWork (IDbContextFactory<PostgreSqlDbContext> dbContextFactory) {
			DbContextFactory = dbContextFactory;
		}

		protected IDbContextFactory<PostgreSqlDbContext> DbContextFactory { get; }
	}
}
