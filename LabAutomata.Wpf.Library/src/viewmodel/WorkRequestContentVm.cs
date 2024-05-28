using LabAutomata.Db.models;
using LabAutomata.Db.repository;
using LabAutomata.Wpf.Library.models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace LabAutomata.Wpf.Library.viewmodel;
public interface IWorkRequestContentVm {
    ObservableCollection<WorkRequestDomainModel> WorkRequests { get; set; }
}

public class WorkRequestContentVm : Base, IWorkRequestContentVm {
    public ObservableCollection<WorkRequestDomainModel> WorkRequests { get; set; } = new();

    public override async Task LoadAsync (CancellationToken token = default) {
        var wrs = await _repository.GetAll(token);
        List<WorkRequestDomainModel> models = new();

        foreach (var wr in wrs) {
            var count = wr.Tests?.Count ?? 0;
            var wrdm = new WorkRequestDomainModel(wr.Name, wr.Program, wr.Description, wr.Started, count);
            models.Add(wrdm);
        }

        WorkRequests = new ObservableCollection<WorkRequestDomainModel>(models);
    }

    public WorkRequestContentVm (IServiceProvider serviceProvider, bool shouldNotifyErrors = false)
        : base(serviceProvider, shouldNotifyErrors) {
        _repository = serviceProvider.GetRequiredService<IRepository<WorkRequest>>();
    }

    private readonly IRepository<WorkRequest> _repository;
}