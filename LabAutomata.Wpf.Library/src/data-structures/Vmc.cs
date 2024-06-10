using LabAutomata.Wpf.Library.viewmodel;

namespace LabAutomata.Wpf.Library.data_structures {

	/// <summary>
	/// Represents a Vmc (Virtual Machine Context) class that implements the IVmc interface.
	/// </summary>
	public class Vmc : Dictionary<string, Base>, IVmc {

		/// <summary>
		/// Gets the value associated with the specified key.
		/// </summary>
		/// <param name="key">The key of the value to get.</param>
		/// <returns>The value associated with the specified key.</returns>
		public Base Get (string key) {
			return this[key];
		}

		/// <summary>
		/// Sets the value associated with the specified key.
		/// </summary>
		/// <param name="key">The key of the value to set.</param>
		/// <param name="value">The value to set.</param>
		public void Set (string key, Base value) {
			Add(key, value);
		}

		/// <summary>
		/// Deletes the value associated with the specified key.
		/// </summary>
		/// <param name="key">The key of the value to delete.</param>
		/// <returns>True if the value is successfully deleted; otherwise, false.</returns>
		public bool Delete (string key) {
			return Remove(key);
		}

		/// <summary>
		/// Get all enumerable values
		/// </summary>
		/// <returns>Enumerable of type Base</returns>
		public IEnumerable<Base> GetValues () {
			return Values;
		}
	}

	/// <summary>
	/// Represents the interface for the Vmc (Virtual Machine Context) class.
	/// </summary>
	public interface IVmc {

		/// <summary>
		/// Gets the value associated with the specified key.
		/// </summary>
		/// <param name="key">The key of the value to get.</param>
		/// <returns>The value associated with the specified key.</returns>
		Base Get (string key);

		/// <summary>
		/// Sets the value associated with the specified key.
		/// </summary>
		/// <param name="key">The key of the value to set.</param>
		/// <param name="value">The value to set.</param>
		void Set (string key, Base value);

		/// <summary>
		/// Deletes the value associated with the specified key.
		/// </summary>
		/// <param name="key">The key of the value to delete.</param>
		/// <returns>True if the value is successfully deleted; otherwise, false.</returns>
		bool Delete (string key);

		/// <summary>
		/// Get all enumerable values
		/// </summary>
		/// <returns>Enumerable of type Base</returns>
		IEnumerable<Base> GetValues ();
	}
}