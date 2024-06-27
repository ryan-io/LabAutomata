using LabAutomata.DataAccess.service;
using LabAutomata.IoT;

namespace LabAutomata.Wpf.Library.mediator_stores;

public class DhtSensorDbWriteStore : IDisposable {
	public DhtSensorDbWriteStore (DhtSensorService service, DhtSensorStore store) {
		_service = service;
		_store = store;

		_store.PayloadDeserialized += WriteToDb;
	}

	public void Dispose () {
		_store.PayloadDeserialized -= WriteToDb;
	}

	void WriteToDb (MqttDht22Payload payload) {
		//_service.Create()
	}

	private readonly DhtSensorService _service;

	private readonly DhtSensorStore _store;
}