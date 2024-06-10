using System.Windows;
using System.Windows.Threading;

namespace LabAutomata.Wpf.Library.adapter {

	public class DispatcherAdapter : IAdapter<Dispatcher> {

		public Dispatcher Get () {
			return _dispatcher;
		}

		public DispatcherAdapter (Application application) {
			_dispatcher = application.Dispatcher;
		}

		private readonly Dispatcher _dispatcher;
	}
}