using LabAutomata.Wpf.Library.viewmodel;
using Microsoft.Extensions.DependencyInjection;

namespace LabAutomata.Wpf.Library.data_structures {
    public class ViewModelCollection {
        private readonly IServiceProvider _sp;
        private readonly Dictionary<string, Base> _dict = new();

        /// <summary>
        /// Gets or sets the view model with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the view model.</param>
        /// <returns>The view model with the specified ID.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when no view model is found with the specified ID.</exception>
        /// <exception cref="NullReferenceException">Thrown when the view model assigned to the specified ID is null.</exception>
        public Base this[string id] {
            // TODO: ugly and prone to errors; it works, but should research an alternative
            get {
                switch (id) {
                    case nameof(NavigationVm):
                        var nvm = _sp.GetService<NavigationVm>();
                        return nvm ?? throw new NullReferenceException(NavVmNotFound);
                    case nameof(WorkRequestVm):
                        var wrvm = _sp.GetService<WorkRequestVm>();
                        return wrvm ?? throw new NullReferenceException(NavVmNotFound);
                    case nameof(CreateWorkRequestVm):
                        var cwrvm = _sp.GetService<CreateWorkRequestVm>();
                        return cwrvm ?? throw new NullReferenceException(NavVmNotFound);
                    case nameof(HomeVm):
                        var hvm = _sp.GetService<HomeVm>();
                        return hvm ?? throw new NullReferenceException(NavVmNotFound);
                    default:
                        throw new NotImplementedException(NotImplemented);
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the ViewModelCollection class.
        /// </summary>
        /// <param name="sp">The service provider.</param>
        /// This class needs to be maintained depending on whether new viewmodels require interaction with the SPA
        public ViewModelCollection (IServiceProvider sp) {
            _sp = sp;
        }

        const string NavVmNotFound = "Navigation view model was no injection properly.";

        private const string NotImplemented =
            "The provided view model key has not been implemented or registered in dependnecy injeciton. Please debug.";
    }
}
