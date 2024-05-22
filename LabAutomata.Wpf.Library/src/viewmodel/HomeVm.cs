namespace LabAutomata.Wpf.Library.viewmodel {

    public class HomeVm : Base {
        public HomeVm (IServiceProvider serviceProvider, bool shouldNotifyErrors = false) : base(serviceProvider, shouldNotifyErrors) {
        }

        public HomeVm (IServiceProvider sp, IServiceProvider serviceProvider) : base(sp, serviceProvider) {
        }
    }
}
