namespace LabAutomata.Wpf.Library.viewmodel;

public class EquipmentItemsVm : Base {
    public EquipmentItemsVm (IServiceProvider serviceProvider, bool shouldNotifyErrors = false) : base(serviceProvider, shouldNotifyErrors) {
    }

    public EquipmentItemsVm (IServiceProvider sp, IServiceProvider serviceProvider) : base(sp, serviceProvider) {
    }
}