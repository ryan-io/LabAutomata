namespace LabAutomata.IoT;

/// <summary>
/// Represents a response from the MQTT strategy.
/// </summary>
/// <typeparam name="T">The type of the response object.</typeparam>
public readonly struct MqttStrategyResponse<T> (T responseObject, bool isError = false) {
	/// <summary>
	/// Gets the response object.
	/// </summary>
	public T ResponseObject { get; } = responseObject;

	// Optional; is there any error during the interpretation?
	public bool IsError { get; } = isError;
}
