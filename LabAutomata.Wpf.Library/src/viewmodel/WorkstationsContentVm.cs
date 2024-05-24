using LabAutomata.Wpf.Library.models;
using System.Collections.ObjectModel;
using LabAutomata.Db.models;
using LabAutomata.Db.repository;
using Microsoft.Extensions.DependencyInjection;

namespace LabAutomata.Wpf.Library.viewmodel;

public class WorkstationsContentVm : Base {
    public ObservableCollection<Workstation> Workstations { get; set; } = new();
    public WorkstationsContentVm (IServiceProvider serviceProvider, bool shouldNotifyErrors = false) 
        : base(serviceProvider, shouldNotifyErrors) {
        _repository = serviceProvider.GetRequiredService<IRepository<Workstation>>();
    }

    private readonly IRepository<Workstation> _repository;
}