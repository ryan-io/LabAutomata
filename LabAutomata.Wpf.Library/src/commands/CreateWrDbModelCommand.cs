using LabAutomata.DataAccess.request;
using LabAutomata.DataAccess.service;
using LabAutomata.Wpf.Library.adapter;
using Microsoft.Extensions.Logging;
using System.Windows.Threading;

namespace LabAutomata.Wpf.Library.commands;

public class CreateWrDbModelCommand : ToDatabaseModelCommand<WorkRequestService> {
	//TODO: the sender 'obj' will need to be refactored to ensure we pass an appropriate object

	public override async Task Create (object? obj) {
		if (obj is not WorkRequestRequest request)
			return;

		try {
			//await Service.CreateWorkRequest(request.to);
			Callback?.Invoke();
			Logger?.LogInformation("Creating DbModel status: - {dM}", request);
		}
		catch (Exception e) {
			Logger?.LogError("An error occurred: {name} - {msg}", nameof(Create), e.InnerException);
			throw;
		}
	}

	public CreateWrDbModelCommand (
		IAdapter<Dispatcher> dA,
		IWorkRequestService service,
		Action? callback = default,
		ILogger? logger = default,
		Func<object?, bool>? canExecute = default)
		: base(dA, null, callback, logger, canExecute) {
	}
}