using Microsoft.Extensions.Logging;

namespace LabAutomata.Wpf.Library.viewmodel;

public class WorkstationsVm : Base {
    public WorkstationsVm (ILogger? logger = default, bool shouldNotifyErrors = false) : base(logger, shouldNotifyErrors) {
    }
}