﻿using LabAutomata.IoT;

namespace LabAutomata.Wpf.Library.contracts;

public interface IDht22PayloadData {
	event Action<MqttDht22Payload>? PayloadDeserialized;
}