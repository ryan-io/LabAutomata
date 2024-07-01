using LabAutomata.Db.common;
using LabAutomata.Db.models;
using LabAutomata.Dto.request;
using LabAutomata.Dto.response;

namespace LabAutomata.DataAccess.mapper;

public class DhtJsondataMapper : IMapper<DhtJsonData, DhtJsonDataRequest, DhtJsonDataResponse> {
	/// <summary>
	/// Converts a DhtJsonDataRequest object to a DhtJsonData object.
	/// </summary>
	/// <param name="request">The DhtJsonDataRequest object.</param>
	/// <returns>The converted DhtJsonData object.</returns>
	public DhtJsonData ToModel (DhtJsonDataRequest request) {
		var sensor = _set.DhtSensors.FirstOrDefault(x => x.Id == request.DhtSensorId);
		//_set.DhtSensors.Entry(sensor).State = EntityState.Detached;
		return new DhtJsonData() {
			DhtSensorId = sensor.Id,
			JsonString = request.JsonString,
			DhtSensor = sensor
		};
	}

	/// <summary>
	/// Converts a DhtJsonData object to a DhtJsonDataResponse object.
	/// </summary>
	/// <param name="model">The DhtJsonData object.</param>
	/// <returns>The converted DhtJsonDataResponse object.</returns>
	public DhtJsonDataResponse ToResponse (DhtJsonData model) {
		return new DhtJsonDataResponse(model.Id, model.JsonString, model.DhtSensorId, model.DhtSensor);
	}

	public DhtJsondataMapper (IDhtSensorSet set) {
		_set = set;
	}

	private readonly IDhtSensorSet _set;
}
