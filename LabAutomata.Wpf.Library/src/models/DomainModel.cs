using LabAutomata.Db.models;

namespace LabAutomata.Wpf.Library.models {
    /// <summary>
    /// Represents an abstract base class for domain models.
    /// </summary>
    /// <typeparam name="T">The type of the associated database model.</typeparam>
    public abstract class DomainModel<T> where T : LabModel {
        /// <summary>
        /// Converts the domain model to its corresponding database model.
        /// </summary>
        /// <returns>The database model.</returns>
        public T ToDbModel () {
            Validate();
            return Create();
        }

        /// <summary>
        /// Allows the user to define mapping for creating a database model from a domain model
        /// </summary>
        /// <returns>A new instance of the db model</returns>
        protected abstract T Create ();

        /// <summary>
        /// Provide validation logic of the domain to database models
        /// This method is expected to throw exceptions
        /// </summary>
        protected abstract void Validate ();
    }
}
