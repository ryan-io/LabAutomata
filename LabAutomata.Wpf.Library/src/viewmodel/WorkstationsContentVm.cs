using LabAutomata.Db.models;
using LabAutomata.Db.repository;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace LabAutomata.Wpf.Library.viewmodel;

/// <summary>
/// Represents the view model for the WorkstationsContent view.
/// </summary>
public class WorkstationsContentVm : Base {
    /// <summary>
    /// Gets or sets the collection of workstations.
    /// </summary>
    public ObservableCollection<Workstation> Workstations { get; set; } = new();

    private readonly IRepository<Workstation> _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="WorkstationsContentVm"/> class.
    /// </summary>
    /// <param name="repository">The repository for workstations.</param>
    /// <param name="logger">The logger.</param>
    public WorkstationsContentVm (IRepository<Workstation> repository, ILogger? logger = default) : base(logger, true) {
        _repository = repository;
    }
}
