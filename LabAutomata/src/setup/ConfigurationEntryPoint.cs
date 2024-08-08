using LabAutomata.Db.common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Windows;

namespace LabAutomata.setup;

internal sealed class ConfigurationEntryPoint {

	public IServiceProvider Configure () {

		var sc = new ServiceCollection();
		ConfigureServices(sc);
		var sp = sc.BuildServiceProvider();

		var vmcConfiguration = new ConfigureVmc(sp);
		vmcConfiguration.Configure();

		return sp;
	}

	private void ConfigureServices (IServiceCollection sc) {
		var asm = Assembly.GetCallingAssembly();
		ArgumentNullException.ThrowIfNull(asm, "Lab Db assembly cannot be null");

		var cb = new ConfigurationBuilder();

		// For DbContext: define user secrets for "LabDatabase"
		//	Get assembly from App.xaml.xs
		//	Create a new configuration builder
		//  Invoke AddUserSecrets on the builder
		//	Call c.Builder and register it as a service
		var secretsConfiguration = new ConfigureSecrets(cb, asm);
		secretsConfiguration.Configure();

		var singletonConfiguration = new ConfigureSingletons(sc, cb);
		singletonConfiguration.Configure();

		var storeConfiguration = new ConfigureStores(sc, cb);
		storeConfiguration.Configure();

		var scopedConfiguration = new ConfigureScoped(sc);
		scopedConfiguration.Configure();

		var transientConfiguration = new ConfigureTransient(sc, _application);
		transientConfiguration.Configure();

		var builder = cb.Build();

		// setting up DbContextFactory for PostgreSQL database
		sc.AddDbContextFactory<PostgreSqlDbContext>(options => options
				.UseNpgsql(builder.GetConnectionString(DatabaseConnectionId))
				.UseSnakeCaseNamingConvention()
				.EnableDetailedErrors());
	}

	internal ConfigurationEntryPoint (Application application) {
		_application = application;
	}

	private readonly Application _application;

	private const string DatabaseConnectionId = "LabDatabase";
}