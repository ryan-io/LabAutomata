using Microsoft.Extensions.Logging;
using MQTTnet.Client;

namespace LabAutomata.IoT;

/// <summary>
/// Represents a Blynk MQTT interpreter.
/// </summary>
public class BlynkMqttInterpreter {
	private readonly ILogger? _logger;

	/// <summary>
	/// Initializes a new instance of the <see cref="BlynkMqttInterpreter"/> class.
	/// </summary>
	/// <param name="client">The MQTT client.</param>
	/// <param name="logger">The logger.</param>
	public BlynkMqttInterpreter (ILogger? logger) {
		_logger = logger;
	}

	/// <summary>
	/// Interprets the MQTT message using the provided interpretation strategy.
	/// </summary>
	/// <param name="interpretation">The interpretation strategy.</param>
	public void Interpret (IMqttInterpretationStrategy interpretation, MqttApplicationMessageReceivedEventArgs e) {
		_logger?.LogInformation(e.ClientId);
		_logger?.LogInformation(e.ApplicationMessage.Topic);

		var value = interpretation.Interpret(e);

		_logger?.LogInformation(value.ToString());
		_logger?.LogInformation(e.ApplicationMessage.PayloadSegment.ToString());
		_logger?.LogInformation(e.ApplicationMessage.ContentType);
	}
}