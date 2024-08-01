using LabAutomata.DataAccess.mapper;
using LabAutomata.Db.models;
using LabAutomata.Db.repository;
using LabAutomata.Dto.request;
using LabAutomata.Dto.response;

namespace LabAutomata.DataAccess.service;

public class DhtSensorService : Service<Dht22Sensor, DhtSensorRequest, DhtSensorResponse> {
	public DhtSensorService (IRepository<Dht22Sensor> repository,
		IMapper<Dht22Sensor, DhtSensorRequest, DhtSensorResponse> mapper) : base(repository, mapper) {
	}
}