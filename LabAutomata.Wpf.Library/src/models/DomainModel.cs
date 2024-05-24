using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LabAutomata.Db.models;

namespace LabAutomata.Wpf.Library.models
{
	/// <summary>
	/// Represents an abstract base class for domain models.
	/// </summary>
	/// <typeparam name="T">The type of the associated database model.</typeparam>
	public abstract class DomainModel<T> : INotifyPropertyChanged, INotifyDataErrorInfo where T : LabModel
	{
		/// <summary>
		/// Event handler for when a property is changed
		/// </summary>
		public event PropertyChangedEventHandler? PropertyChanged;

		/// <summary>
		/// Converts the domain model to its corresponding database model.
		/// </summary>
		/// <returns>The database model.</returns>
		public T ToDbModel()
		{
			Validate();
			return Create();
		}

        /// <summary>
        /// Allows the user to define mapping for creating a database model from a domain model
        /// </summary>
        /// <returns>A new instance of the db model</returns>
        public abstract T Create();

		/// <summary>
		/// Provide validation logic of the domain to database models
		/// This method is expected to throw exceptions
		/// </summary>
		public abstract void Validate();

		protected void NotifyPropertyChanged([CallerMemberName] string? propertyName = null)
			=> PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

		/// <summary>
		///  Raised when any errors have been added to error collection
		/// </summary>
		public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

		/// <summary>
		///  Returns all cached errors from parameter propertyName if the errors collection contains this property
		/// </summary>
		/// <param name="propertyName">Property to check for thrown errors</param>
		/// <returns>Enumeration of each error for _errors[propertyName]</returns>
		public IEnumerable GetErrors ([CallerMemberName] string? propertyName = default) {
			if (string.IsNullOrWhiteSpace(propertyName) || !_errors.ContainsKey(propertyName))
				return Enumerable.Empty<string>();

			return _errors[propertyName];
		}

		/// <summary>
		/// Gets an unordered list of all errors, independent of property
		/// </summary>
		/// <returns>A list containing all current errors</returns>
		public List<string> GetErrorsList () {
			List<string> errors = new();

            foreach (var errorsValue in _errors.Values)
            {
                errors.AddRange(errorsValue);
            }

            return errors;
        }

		public bool HasErrors => _errors.Any();

		/// <summary>
		///  Raises ErrorsChanged event
		/// </summary>
		/// <param name="args">Relevant data transfer object</param>
		protected virtual void OnErrorsChanged (DataErrorsChangedEventArgs args) {
			ErrorsChanged?.Invoke(this, args);
		}

		/// <summary>
		///  Removes a specific error from _errors for propertyName
		/// </summary>
		/// <param name="propertyName">Property to remove the error from</param>
		protected void RemoveErrorsFor ([CallerMemberName] string? propertyName = default) {
			if ( string.IsNullOrWhiteSpace(propertyName))
				return;

			if (!_errors.ContainsKey(propertyName))
				return;

			var success = _errors.Remove(propertyName);

			if (success) {
				OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
				NotifyPropertyChanged(nameof(HasErrors)); // in case a element in the UI databinds to this property
			}
		}

		/// <summary>
		///  Clears a list of errors from _errors for the given propertyName
		/// </summary>
		/// <param name="propertyName">Property to clear the error list for</param>
		protected void ClearErrorsForProperty ([CallerMemberName] string? propertyName = default) {
			if (string.IsNullOrWhiteSpace(propertyName))
				return;

			if (!_errors.TryGetValue(propertyName, out var error))
				return;

			error.Clear();
			OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
			NotifyPropertyChanged(nameof(HasErrors));
		}

		/// <summary>
		///  Trys to add error if _errors does not contain it.
		/// </summary>
		/// <param name="error">Error to add</param>
		/// <param name="propertyName">Property to associate the error with</param>
		protected void AddError (string error, [CallerMemberName] string? propertyName = default) {
			if (string.IsNullOrWhiteSpace(propertyName))
				return;

			if (!_errors.ContainsKey(propertyName)) {
				_errors.Add(propertyName, []);
			}

			if (_errors[propertyName].Contains(error))
				return;

			_errors[propertyName].Add(error);
			OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
			NotifyPropertyChanged(nameof(HasErrors));    // in case a element in the UI databinds to this property
		}

		/// <summary>
		///  Queries _errors for propertyName and returns a list of errors
		/// </summary>
		/// <param name="propertyName">Property to query</param>
		/// <param name="error">Enumerable of strings containing error messages</param>
		/// <returns>True if there are errors for propertyName</returns>
		protected bool TryGetErrorString (string? propertyName, out IEnumerable<string>? error) {
			error = Enumerable.Empty<string>();

			if (string.IsNullOrWhiteSpace(propertyName)) {
				return false;
			}

			error = _errors[propertyName];

			return true;
		}
		
        readonly Dictionary<string, List<string>> _errors = new();
	}
}