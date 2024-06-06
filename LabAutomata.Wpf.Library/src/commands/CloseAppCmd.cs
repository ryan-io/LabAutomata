using LabAutomata.Wpf.Library.common;
using System.Windows;

namespace LabAutomata.Wpf.Library.commands {
	public class CloseAppCmd : Command {
		public CloseAppCmd () {
			ContextAction = Close;
		}

		void Close (object? sender) {
			// TODO: provide shutdown codes in the future for handling additional exit logic


			Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
			Application.Current.Shutdown();
		}
	}

}
