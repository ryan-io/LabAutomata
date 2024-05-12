using LabAutomata.Db.common;
using LabAutomata.Db.models;

namespace LabAutomata.Db.repository {
    /// <summary>
    /// The SsTemperatureRepository class provides methods for interacting with the SteadyStateTemperatureTest entities in the database.
    /// </summary>
    /// <remarks>
    /// This class implements the IRepository interface for the SteadyStateTemperatureTest entity.
    /// </remarks>
    public class SsTemperatureRepository (LabPostgreSqlDbContext dbCtx) : IRepository<SteadyStateTemperatureTest> {
        /// <summary>
        /// Asynchronously creates a new SteadyStateTemperatureTest entity in the database.
        /// </summary>
        /// <param name="entity">The SteadyStateTemperatureTest entity to create.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        /// <remarks>
        /// This method adds the entity to the SsTempTests DbSet and then saves the changes to the database.
        /// </remarks>
        public async Task Create (SteadyStateTemperatureTest entity) {
            await dbCtx.SsTempTests.AddAsync(entity);
            await dbCtx.SaveChangesAsync();
        }

        /// <summary>
        /// Retrieves a SteadyStateTemperatureTest entity from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the SteadyStateTemperatureTest entity to retrieve.</param>
        /// <returns>The SteadyStateTemperatureTest entity with the specified ID, or null if no such entity exists.</returns>
        /// <remarks>
        /// This method uses LINQ to query the SsTempTests DbSet for an entity with the specified ID.
        /// </remarks>
        public SteadyStateTemperatureTest? Get (int id) {
            var output = dbCtx.SsTempTests.FirstOrDefault(t => t.Id == id);
            return output;
        }

        /// <summary>
        /// Asynchronously updates a SteadyStateTemperatureTest entity in the database.
        /// </summary>
        /// <param name="entity">The SteadyStateTemperatureTest entity to update.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        /// <remarks>
        /// This method marks the entity as modified and then saves the changes to the database.
        /// </remarks>
        public async Task Update (SteadyStateTemperatureTest entity) {
            dbCtx.Update(entity);
            await dbCtx.SaveChangesAsync();
        }

        /// <summary>
        /// Asynchronously deletes a SteadyStateTemperatureTest entity from the database.
        /// </summary>
        /// <param name="entity">The SteadyStateTemperatureTest entity to delete.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        /// <remarks>
        /// This method removes the entity from the SsTempTests DbSet and then saves the changes to the database.
        /// </remarks>
        public async Task Delete (SteadyStateTemperatureTest entity) {
            dbCtx.Remove(entity);
            await dbCtx.SaveChangesAsync();
        }
    }
}