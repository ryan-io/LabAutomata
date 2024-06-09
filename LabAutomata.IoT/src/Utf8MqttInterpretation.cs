using MQTTnet.Client;
using System.Buffers.Text;

namespace LabAutomata.IoT;

public class Utf8MqttInterpretation : IMqttInterpretationStrategy<float> {
	/// <summary>
	/// Interprets the MQTT application message payload as a float value.
	/// </summary>
	/// <param name="e">The MQTT application message received event arguments.</param>
	/// <returns>The interpreted float value.</returns>
	public MqttStrategyResponse<float> Interpret (MqttApplicationMessageReceivedEventArgs e) {
		var status = Utf8Parser.TryParse(e.ApplicationMessage.PayloadSegment, out float value, out var _);
		return new MqttStrategyResponse<float>(value, status);
	}

}