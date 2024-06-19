using LabAutomata.DataAccess.mapper;
using LabAutomata.Db.models;
using LabAutomata.Db.repository;
using LabAutomata.Dto.request;
using LabAutomata.Dto.response;

namespace LabAutomata.DataAccess.service;

public class SeedJsonService (
	IRepository<SeedJson> repository,
	IMapper<SeedJson, SeedJsonRequest, SeedJsonResponse> mapper)
	: Service<SeedJson, SeedJsonRequest, SeedJsonResponse>(repository, mapper);