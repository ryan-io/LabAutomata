namespace LabAutomata.IoT {
	public struct MqttDht22Payload {
		public float Temperature { get; init; }
		public float RelHumidity { get; init; }
		public float TimeStamp { get; init; }

		public MqttDht22Payload (float temperature, float relHumidity, float timeStamp) {
			Temperature = temperature;
			RelHumidity = relHumidity;
			TimeStamp = timeStamp;
		}
	}
}
