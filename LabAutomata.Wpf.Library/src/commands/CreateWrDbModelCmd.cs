﻿using LabAutomata.Db.models;
using LabAutomata.Db.repository;
using LabAutomata.Wpf.Library.adapter;
using LabAutomata.Wpf.Library.domain_models;
using Microsoft.Extensions.Logging;
using System.Windows.Threading;

namespace LabAutomata.Wpf.Library.commands;

public class CreateWrDbModelCmd : CreateDbModelCmd<WorkRequestDomainModel, WorkRequest> {

	public CreateWrDbModelCmd (IAdapter<Dispatcher> dA,
		IRepository<WorkRequest>? repository,
		Action? callback = default,
		ILogger? logger = default,
		Func<object?, bool>? canExecute = default) : base(dA, repository, callback, logger, canExecute) {
	}
}