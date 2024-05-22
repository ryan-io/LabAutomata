using LabAutomata.Db.models;
using LabAutomata.Db.repository;
using LabAutomata.Wpf.Library.adapter;
using LabAutomata.Wpf.Library.models;
using System.Windows.Threading;

namespace LabAutomata.Wpf.Library.commands;

public class CreateWrDbModelCmd (
    IAdapter<Dispatcher> dA,
    IRepository<WorkRequest> repository,
    Func<object?, bool>? canExecute = null)
    : CreateDbModelCmd<WorkRequestDomainModel, WorkRequest>(dA, repository, canExecute);