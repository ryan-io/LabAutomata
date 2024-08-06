using LabAutomata.DataAccess.request;
using LabAutomata.DataAccess.unit_of_work;
using LabAutomata.IoT;
using LabAutomata.Wpf.Library.contracts;

namespace LabAutomata.Wpf.Library.mediator_stores;

public interface IDhtSensorDataWriter {
	/// <summary>
	/// Async void method for writing MQTT DHT22 payload to a JSONB format in PostgreSQL
	/// This class should have it's Dispose method invoked if objects are not instantiated
	///		as singletons
	/// </summary>
	/// <param name="obj">DHT22 Payload</param>
	void Dht22DataOnPayloadDeserialized (MqttDht22Payload obj);
}

public class DhtSensorDataWriter : IDhtSensorDataWriter {
	public void Dispose () {
		_dht22Data.PayloadDeserialized -= Dht22DataOnPayloadDeserialized;
	}

	public DhtSensorDataWriter (IDht22PayloadData dht22Data, IDht22SensorDataUnitOfWork unitOfWork) {
		_dht22Data = dht22Data;
		_dht22Data.PayloadDeserialized += Dht22DataOnPayloadDeserialized;
		_unitOfWork = unitOfWork;
	}

	/// <summary>
	/// Async void method for writing MQTT DHT22 payload to a JSONB format in PostgreSQL
	/// This class should have it's Dispose method invoked if objects are not instantiated
	///		as singletons
	/// </summary>
	public async void Dht22DataOnPayloadDeserialized (MqttDht22Payload obj) {
		if (string.IsNullOrWhiteSpace(obj.Raw))
			return;

		//TODO: optimize this method in regard to number of database calls
		var request = new Dht22AddDataToSensorRequest(obj.DhtSensorId, obj.Raw);
		await _unitOfWork.RunWork(request, CancellationToken.None);
	}

	private readonly IDht22PayloadData _dht22Data;
	private readonly IDht22SensorDataUnitOfWork _unitOfWork;
}