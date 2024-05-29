using Microsoft.Extensions.Logging;

namespace LabAutomata.Wpf.Library.viewmodel;

public class EquipmentItemsContentVm : Base {
    public EquipmentItemsContentVm (ILogger? logger = default, bool shouldNotifyErrors = false) : base(logger, shouldNotifyErrors) {
    }
}