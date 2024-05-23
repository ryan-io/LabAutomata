using System.Windows;
using LabAutomata.Wpf.Library.common;

namespace LabAutomata.Wpf.Library.commands {
	public class CloseAppCmd : Command{
		public CloseAppCmd() : base()
		{
			ContextAction = Close;
		}

		void Close (object? sender) {
			// TODO: provide shutdown codes in the future for handling additional exit logic
			Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
			Application.Current.Shutdown();
		}
	}

}
