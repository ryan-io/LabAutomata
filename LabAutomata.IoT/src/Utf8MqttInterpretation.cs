using MQTTnet.Client;
using System.Buffers.Text;

namespace LabAutomata.IoT;

public class Utf8MqttInterpretation : IMqttInterpretationStrategy {
	/// <summary>
	/// Interprets the MQTT application message payload as a float value.
	/// </summary>
	/// <param name="e">The MQTT application message received event arguments.</param>
	/// <returns>The interpreted float value.</returns>
	public float Interpret (MqttApplicationMessageReceivedEventArgs e) {
		Utf8Parser.TryParse(e.ApplicationMessage.PayloadSegment, out float value, out var _);
		return value;
	}
}
