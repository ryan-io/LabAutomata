using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace LabAutomata.Wpf.Library.control {

	public class ControlNotify : UserControl, INotifyPropertyChanged {

		/// <summary>
		///  Raised when a property for this instance is changed
		/// </summary>
		public event PropertyChangedEventHandler? PropertyChanged;

		/// <summary>
		///  If no property is specified, CallerMemberName will be automatically populated with the member that invoked this method
		///     This will be member 'Source' in all instances
		/// </summary>
		/// <param name="propertyName">Name of property that changed</param>
		protected virtual void NotifyPropertyChanged ([CallerMemberName] string? propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}