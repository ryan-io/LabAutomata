using LabAutomata.Wpf.Library.mediator_stores;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LabAutomata.setup;

public class PersistentStoreEntryPoint {
	/// <summary>
	/// Starts up the persistent store.
	/// </summary>
	/// <param name="appCancellationToken">The cancellation token for the application.</param>
	public async Task Startup (CancellationToken appCancellationToken = default) {
		var workstationStore = _serviceProvider.GetRequiredService<WorkstationStore>();
		await workstationStore.Load(appCancellationToken);
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="PersistentStoreEntryPoint"/> class.
	/// </summary>
	/// <param name="sp">The service provider.</param>
	public PersistentStoreEntryPoint (IServiceProvider sp) {
		_serviceProvider = sp;
		_logger = _serviceProvider.GetRequiredService<ILogger>();
	}

	private readonly IServiceProvider _serviceProvider;
	private readonly ILogger _logger;
}
