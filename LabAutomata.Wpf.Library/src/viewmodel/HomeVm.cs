using Microsoft.Extensions.Logging;

namespace LabAutomata.Wpf.Library.viewmodel {

    public class HomeVm : Base {
        public HomeVm (ILogger? logger = default) : base(logger, true) {
        }
    }
}
