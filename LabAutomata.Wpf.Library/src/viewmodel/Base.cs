using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LabAutomata.Wpf.Library.viewmodel {
    public abstract class Base : INotifyPropertyChanged, INotifyDataErrorInfo {
        /// <summary>
        ///  Raised when a property for this instance is changed
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        ///  Raised when any errors have been added to error collection
        /// </summary>
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        /// <summary>
        /// Notifies any listeners that this instance has completed its load process
        /// </summary>
        public bool HasLoaded {
            get => _hasLoaded;
            set {
                _hasLoaded = value;
                NotifyPropertyChanged();
            }
        }

        public ILogger? Logger => ServiceProvider.GetService<ILogger>();

        /// <summary>
        ///  If instance should notify about errors, will check if errors collection contains any elements
        ///  else, returns false
        /// </summary>
        public bool HasErrors {
            get {
                if (!_shouldNotifyErrors)
                    return false;

                return _errors.Any();
            }
        }
        public virtual Task LoadAsync (CancellationToken token = default) => Task.CompletedTask;

        public virtual void Load () {
        }

        /// <summary>
        ///  Resets the instance to an initial state
        /// </summary>
        /// <param name="sender"></param>
        public virtual void Reset (object? sender) { }

        /// <summary>
        ///  If no property is specified, CallerMemberName will be automatically populated with the member that invoked this method
        ///     This will be member 'Source' in all instances
        /// </summary>
        /// <param name="property">Name of property that changed</param>
        protected virtual void NotifyPropertyChanged ([CallerMemberName] string? property = default) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        /// <summary>
        ///  Returns all cached errors from parameter propertyName if the errors collection contains this property
        /// </summary>
        /// <param name="propertyName">Property to check for thrown errors</param>
        /// <returns>Enumeration of each error for _errors[propertyName]</returns>
        public IEnumerable GetErrors ([CallerMemberName] string? propertyName = default) {
            if (!_shouldNotifyErrors || string.IsNullOrWhiteSpace(propertyName))
                return Enumerable.Empty<string>();

            return _errors[propertyName];
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="shouldNotifyErrors">Default yes, will not add, remove, clear, or propogate events that pertain to errors</param>
        public Base (bool shouldNotifyErrors = false) {
            _shouldNotifyErrors = shouldNotifyErrors;
            _errors = new Dictionary<string, List<string>>();
        }

        /// <summary>
        ///  Raises ErrorsChanged event
        /// </summary>
        /// <param name="args">Relevent data transfer object</param>
        protected virtual void OnErrorsChanged (DataErrorsChangedEventArgs args) {
            if (!_shouldNotifyErrors)
                return;

            ErrorsChanged?.Invoke(this, args);
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
                _errors.Add(propertyName, new List<string>());
            }

            if (_errors[propertyName].Contains(error))
                return;

            _errors[propertyName].Add(error);
            OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
            NotifyPropertyChanged(nameof(HasErrors));    // in case a element in the UI databinds to this property
        }

        /// <summary>
        ///  Removes a specific error from _errors for propertyName
        /// </summary>
        /// <param name="propertyName">Property to remove the error from</param>
        protected void RemoveErrorsForProperty ([CallerMemberName] string? propertyName = default) {
            if (!_shouldNotifyErrors || string.IsNullOrWhiteSpace(propertyName))
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

        // services registered through DI in the application
        protected IServiceProvider ServiceProvider { get; }

        protected Base (IServiceProvider sp) {
            ServiceProvider = sp;
            _shouldNotifyErrors = true;
        }

        readonly bool _shouldNotifyErrors;
        readonly Dictionary<string, List<string>> _errors = new();
        private bool _hasLoaded;
    }
}
