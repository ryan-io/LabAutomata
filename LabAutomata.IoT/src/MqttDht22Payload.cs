using Newtonsoft.Json;

namespace LabAutomata.IoT {
	public readonly struct MqttDht22Payload (float temperature, float relativeHumidity) {
		[JsonProperty("temp")]
		public float Temperature { get; init; } = temperature;

		[JsonProperty("rh")]
		public float RelativeHumidity { get; init; } = relativeHumidity;

		public int Year { get; init; }

		public int Month { get; init; }

		public int Day { get; init; }

		public int Hour { get; init; }

		[JsonProperty("min")]
		public int Minute { get; init; }

		[JsonProperty("sec")]
		public int Second { get; init; }
	}
}