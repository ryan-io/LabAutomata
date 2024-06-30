using LabAutomata.DataAccess.mapper;
using LabAutomata.DataAccess.service;
using LabAutomata.Db.common;
using LabAutomata.Db.models;
using LabAutomata.Db.repository;
using LabAutomata.Dto.request;
using LabAutomata.Dto.response;
using LabAutomata.Wpf.Library.adapter;
using LabAutomata.Wpf.Library.common;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Threading;

namespace LabAutomata.setup;

internal sealed class ConfigureTransient {
	private readonly IServiceCollection _sc;

	public void Configure () {
		_sc.AddTransient<MainWindow>();
		_sc.AddTransient<ILabPostgreSqlDbContext, LabPostgreSqlDbContext>();
		_sc.AddTransient<IAdapter<Dispatcher>>(_ => new DispatcherAdapter(_app));

		// database repositories
		_sc.AddTransient<IVmIdExtractor, VmIdExtractor>();
		_sc.AddTransient<IRepository<WorkRequest>, WorkRequestRepository>();
		_sc.AddTransient<IRepository<Workstation>, WorkstationRepository>();
		_sc.AddTransient<IRepository<Personnel>, PersonnelRepository>();
		_sc.AddTransient<IRepository<Location>, LocationRepository>();
		_sc.AddTransient<IRepository<TestType>, TestTypeRepository>();
		_sc.AddTransient<IRepository<SeedJson>, SeedDataRepository>();
		_sc.AddTransient<IRepository<Test>, SteadyStateTemperatureTest>();
		_sc.AddTransient<IRepository<Equipment>, EquipmentRepository>();
		_sc.AddTransient<IRepository<DhtJsonData>, DhtJsonDataRepository>();
		_sc.AddTransient<IRepository<DhtSensor>, DhtSensorRepository>();
		_sc.AddTransient<IRepository<Manufacturer>, ManufacturerRepository>();
		_sc.AddTransient<IRepositoryCreate<SeedJson>>(sp => sp.GetRequiredService<IRepository<SeedJson>>());
		_sc.AddTransient<IRepositoryGet<SeedJson>>(sp => sp.GetRequiredService<IRepository<SeedJson>>());

		// data access services 
		_sc.AddTransient<IService<WorkstationRequest, WorkstationResponse>, WorkstationService>();
		_sc.AddTransient<IService<DhtJsonDataRequest, DhtJsonDataResponse>, DhtJsonDataService>();

		// mappers
		_sc.AddTransient<IMapper<Workstation, WorkstationRequest, WorkstationResponse>, WorkstationMapper>();
		_sc.AddTransient<IMapper<DhtJsonData, DhtJsonDataRequest, DhtJsonDataResponse>, DhtJsondataMapper>();
	}

	public ConfigureTransient (IServiceCollection sc, Application app) {
		_sc = sc;
		_app = app;
	}

	private Application _app;
}