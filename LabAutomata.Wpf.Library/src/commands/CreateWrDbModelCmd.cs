using LabAutomata.Db.models;
using LabAutomata.Db.repository;
using LabAutomata.Wpf.Library.adapter;
using LabAutomata.Wpf.Library.models;
using System.Windows.Threading;
using Microsoft.Extensions.Logging;

namespace LabAutomata.Wpf.Library.commands;

public class CreateWrDbModelCmd(
	IAdapter<Dispatcher> dA,
	IRepository<WorkRequest>? repository,
	ILogger? logger = default,
	Func<object?, bool>? canExecute = default)
	: CreateDbModelCmd<WorkRequestDomainModel, WorkRequest>(dA, repository, logger, canExecute);