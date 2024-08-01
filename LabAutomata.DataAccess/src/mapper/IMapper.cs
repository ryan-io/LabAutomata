namespace LabAutomata.DataAccess.mapper;

public interface IMapper<TRequest, TResponse> {
	TRequest ToRequest (TResponse request);
	TResponse ToResponse (TModel model);
}