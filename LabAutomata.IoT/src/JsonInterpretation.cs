using MQTTnet.Client;

namespace LabAutomata.IoT;

public class JsonInterpretation : IMqttInterpretationStrategy<string?> {
	/// <summary>
	/// Interprets the MQTT application message received and converts it to a string.
	/// </summary>
	/// <param name="e">The MQTT application message received event arguments.</param>
	/// <returns>A response containing the converted string and an error flag.</returns>
	public MqttStrategyResponse<string?> Interpret (MqttApplicationMessageReceivedEventArgs e) {
		/* json form (example):
		 {
			 "RelativeHumidity": 43.0,                                        // Temperature data
			 "TimeStamp": "2024-06-09T07:55:22.3889779-05:00"    // timestamp data
		  }
		 */

		if (e.ApplicationMessage.PayloadSegment.Count < 1)
			return new MqttStrategyResponse<string?>(null, true);

		var strConversion = System.Text.Encoding.UTF8.GetString(e.ApplicationMessage.PayloadSegment);
		var isError = string.IsNullOrWhiteSpace(strConversion);

		return new MqttStrategyResponse<string?>(strConversion, isError);
	}
}