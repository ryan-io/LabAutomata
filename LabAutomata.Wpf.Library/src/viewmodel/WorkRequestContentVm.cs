namespace LabAutomata.Wpf.Library.viewmodel;

public class WorkRequestContentVm : Base {
    public WorkRequestContentVm (IServiceProvider serviceProvider, bool shouldNotifyErrors = false) : base(serviceProvider, shouldNotifyErrors) {
    }

    public WorkRequestContentVm (IServiceProvider sp, IServiceProvider serviceProvider) : base(sp, serviceProvider) {
    }
}