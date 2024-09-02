using System.Collections.ObjectModel;
using System.Windows;

namespace LabAutomata.Wpf.Library.common {
	/// <summary>
	/// This class references https://learn.microsoft.com/en-us/dotnet/desktop/wpf/properties/collection-type-dependency-properties?view=netdesktop-8.0
	/// Registers a generic dependency property that is a collection of type 'T' to an observable collection
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class GenericDependencyObject<T> : DependencyObject {
		private static readonly DependencyPropertyKey s_genericDependencyObjectKey =
			DependencyProperty.RegisterReadOnly(
				name: Name,
				propertyType: typeof(ObservableCollection<T>),
				ownerType: typeof(GenericDependencyObject<T>),
				typeMetadata: new FrameworkPropertyMetadata()
			//typeMetadata: new FrameworkPropertyMetadata(new ObservableCollection<T>())  // specify the default for reference type
			// use the commented out 'typeMetadata' to specify the default value for the collection IF the list should be shared between
			//	instances
			);

		// Set the default collection value in a class constructor.
		// Per Microsoft documentation:
		/*
		 * So, when the intent is for each object instance to have its own list, the default value should be set in the class constructor.
		 */
		public GenericDependencyObject () => SetValue(s_genericDependencyObjectKey, new ObservableCollection<T>());

		// Declare a public get accessor.
		public ObservableCollection<T> Items => (ObservableCollection<T>)GetValue(s_genericDependencyObjectKey.DependencyProperty);

		private const string Name = "GenericPropertyContents";
	}
}
