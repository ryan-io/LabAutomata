namespace LabAutomata.Wpf.Library.viewmodel;

public class WorkstationsVm : Base {
    public WorkstationsVm (IServiceProvider serviceProvider, bool shouldNotifyErrors = false) : base(serviceProvider, shouldNotifyErrors) {
    }

    public WorkstationsVm (IServiceProvider sp, IServiceProvider serviceProvider) : base(sp, serviceProvider) {
    }
}