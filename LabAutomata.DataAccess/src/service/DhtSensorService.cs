using LabAutomata.DataAccess.mapper;
using LabAutomata.Db.models;
using LabAutomata.Db.repository;
using LabAutomata.Dto.request;
using LabAutomata.Dto.response;

namespace LabAutomata.DataAccess.service;

public class DhtSensorService : Service<DhtSensor, DhtSensorRequest, DhtSensorResponse> {
	public DhtSensorService (IRepository<DhtSensor> repository,
		IMapper<DhtSensor, DhtSensorRequest, DhtSensorResponse> mapper) : base(repository, mapper) {
	}
}