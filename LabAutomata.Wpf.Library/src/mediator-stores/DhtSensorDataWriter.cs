using LabAutomata.DataAccess.service;
using LabAutomata.Dto.request;
using LabAutomata.Dto.response;
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

	public DhtSensorDataWriter (IDht22PayloadData dht22Data, IService<DhtJsonDataRequest, DhtJsonDataResponse> serviceProvider) {
		_dht22Data = dht22Data;
		_serviceProvider = serviceProvider;
		_dht22Data.PayloadDeserialized += Dht22DataOnPayloadDeserialized;
	}

	/// <summary>
	/// Async void method for writing MQTT DHT22 payload to a JSONB format in PostgreSQL
	/// This class should have it's Dispose method invoked if objects are not instantiated
	///		as singletons
	/// </summary>
	/// <param name="obj">DHT22 Payload</param>
	public async void Dht22DataOnPayloadDeserialized (MqttDht22Payload obj) {
		if (string.IsNullOrWhiteSpace(obj.Raw))
			return;

		var request = new DhtJsonDataRequest(obj.Raw, obj.DhtSensorId);
		//await _serviceProvider.Create(request);
	}

	private readonly IService<DhtJsonDataRequest, DhtJsonDataResponse> _serviceProvider;
	private readonly IDht22PayloadData _dht22Data;
}