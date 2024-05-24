using System.Collections.ObjectModel;
using LabAutomata.Db.models;
using LabAutomata.Db.repository;
using LabAutomata.Wpf.Library.common;
using LabAutomata.Wpf.Library.models;
using Microsoft.Extensions.DependencyInjection;

namespace LabAutomata.Wpf.Library.viewmodel;

public class WorkRequestContentVm : Base {
    public ObservableCollection<WorkRequestDomainModel> WorkRequests { get; set; } = new();

    public override async Task LoadAsync (CancellationToken token = default) {
        var wrs = await _repository.GetAll(token);
        List<WorkRequestDomainModel> models = new();

        foreach (var wr in wrs)
        {
            var wrdm = new WorkRequestDomainModel(wr.Name, wr.Program, wr.Description, wr.Started, wr.Tests);
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