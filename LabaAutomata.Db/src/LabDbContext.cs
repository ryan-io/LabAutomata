using Microsoft.EntityFrameworkCore;

namespace LabaAutomata.Db.src {
    public class LabDbContext (IConnectionString connectionString) : DbContext {
        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            //base.OnConfiguring(optionsBuilder);

            // gets connection string from our appsettings.json
            optionsBuilder.UseNpgsql(connectionString.Get);
        }
    }
}
