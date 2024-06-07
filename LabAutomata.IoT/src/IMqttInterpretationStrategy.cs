using MQTTnet.Client;

namespace LabAutomata.IoT;

/*
 * ~~~~~~~~~~~~~ example implementation
 * payloads are ASSUMED to be represented as a byte[] (span<byte>)
 *  if JSON is required, a new strategy contract will need to be defined & implemented
 * public class MyMqttInterpretationStrategy : IMqttInterpretationStrategy
{
    public float Interpret(MqttApplicationMessageReceivedEventArgs e)
    {
        // Your interpretation logic here
        // Access the MQTT message properties like e.ClientId, e.ApplicationMessage.Topic, etc.
        // Perform any necessary calculations or transformations on the message data
        // Return the interpreted value as a float

        // For example, let's say the MQTT message payload contains a temperature value in Celsius
        // and we want to convert it to Fahrenheit
        var celsius = float.Parse(Encoding.UTF8.GetString(e.ApplicationMessage.Payload));
        var fahrenheit = (celsius * 9 / 5) + 32;

        return fahrenheit;
    }
}
 */

public interface IMqttInterpretationStrategy {
	float Interpret (MqttApplicationMessageReceivedEventArgs e);
}