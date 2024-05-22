namespace LabAutomata.Wpf.Library.viewmodel {
    public class WorkRequestVm : Base {
        public WorkRequestVm (IServiceProvider serviceProvider, bool shouldNotifyErrors = false) : base(serviceProvider, shouldNotifyErrors) {
        }

        public WorkRequestVm (IServiceProvider sp, IServiceProvider serviceProvider) : base(sp, serviceProvider) {
        }
    }
}
