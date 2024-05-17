using LabAutomata.Wpf.Library.adapter;
using LabAutomata.Wpf.Library.common;
using System.Windows.Input;

namespace LabAutomata.Wpf.Library.viewmodel {
    public class MainWindowVm : Base {
        private ICommand DragWindow { get; }

        public MainWindowVm (IAdapter dragWindowAdapter) {
            DragWindow = new DelegateCommand(_ => dragWindowAdapter.Get());
        }
    }
}
