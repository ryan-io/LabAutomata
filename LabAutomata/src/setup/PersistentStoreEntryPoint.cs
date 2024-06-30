using LabAutomata.Wpf.Library.mediator_stores;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LabAutomata.setup;

public class PersistentStoreEntryPoint {
	/// <summary>
	/// Starts up the persistent store.
	/// Creates a list of tasks and adds the async 'Load' method from multiple stores to it
	/// Task.WhenAll is then invoked and the tasks list as passed as a parameter
	/// this call is await
	/// callers should await this method
	/// </summary>
	/// <param name="appCancellationToken">The cancellation token for the application.</param>
	public async Task Startup (CancellationToken appCancellationToken = default) {
		var tasks = new List<Task>();
		var workstationStore = _serviceProvider.GetRequiredService<IWorkstationStore>();
		var dhtDataWriterStore = _serviceProvider.GetRequiredService<IDhtSensorDataWriter>();
		tasks.Add(workstationStore.Load(appCancellationToken));

		await Task.WhenAll(tasks);
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
