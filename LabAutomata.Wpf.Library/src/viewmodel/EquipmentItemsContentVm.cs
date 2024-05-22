namespace LabAutomata.Wpf.Library.viewmodel;

public class EquipmentItemsContentVm : Base {
    public EquipmentItemsContentVm (IServiceProvider serviceProvider, bool shouldNotifyErrors = false) : base(serviceProvider, shouldNotifyErrors) {
    }

    public EquipmentItemsContentVm (IServiceProvider sp, IServiceProvider serviceProvider) : base(sp, serviceProvider) {
    }
}