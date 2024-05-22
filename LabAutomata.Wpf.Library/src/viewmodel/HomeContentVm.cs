namespace LabAutomata.Wpf.Library.viewmodel;

public class HomeContentVm : Base {
    public HomeContentVm (IServiceProvider serviceProvider, bool shouldNotifyErrors = false) : base(serviceProvider, shouldNotifyErrors) {
    }

    public HomeContentVm (IServiceProvider sp, IServiceProvider serviceProvider) : base(sp, serviceProvider) {
    }
}