namespace LabAutomata.Wpf.Library.viewmodel;

public class WorkstationsContentVm : Base {
    public WorkstationsContentVm (IServiceProvider serviceProvider, bool shouldNotifyErrors = false) : base(serviceProvider, shouldNotifyErrors) {
    }

    public WorkstationsContentVm (IServiceProvider sp, IServiceProvider serviceProvider) : base(sp, serviceProvider) {
    }
}