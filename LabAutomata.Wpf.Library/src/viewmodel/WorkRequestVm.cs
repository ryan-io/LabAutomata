using Microsoft.Extensions.Logging;

namespace LabAutomata.Wpf.Library.viewmodel {

	public class WorkRequestVm : Base {

		public WorkRequestVm (ILogger? logger = default, bool shouldNotifyErrors = false) : base(logger, shouldNotifyErrors) {
		}
	}
}