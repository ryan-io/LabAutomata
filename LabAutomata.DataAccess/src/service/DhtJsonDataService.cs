using LabAutomata.DataAccess.mapper;
using LabAutomata.Db.models;
using LabAutomata.Db.repository;
using LabAutomata.Dto.request;
using LabAutomata.Dto.response;

namespace LabAutomata.DataAccess.service;

public class DhtJsonDataService : Service<DhtJsonData, DhtJsonDataRequest, DhtJsonDataResponse> {
	public DhtJsonDataService (
		IRepository<DhtJsonData> repository,
		IMapper<DhtJsonData, DhtJsonDataRequest, DhtJsonDataResponse> mapper)
		: base(repository, mapper) {
	}
}