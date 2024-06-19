using LabAutomata.Db.models;

namespace LabAutomata.DataAccess.mapper;

public interface IMapper<TModel, in TRequest, out TResponse> where TModel : LabModel {
	TModel ToModel (TRequest request);
	TResponse ToResponse (TModel model);
}