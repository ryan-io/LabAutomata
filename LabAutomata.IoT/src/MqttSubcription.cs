namespace LabAutomata.IoT;

[Serializable, Flags]
public enum MqttSubcription {
	None = 1 << 0,
	Uplink = 1 << 1,
	Downlink = 1 << 2,
}