using LabAutomata.DataAccess.common;
using LabAutomata.DataAccess.response;

namespace LabAutomata.DataAccess.request;

/// <summary>
/// Requests an already existing Dht22Data point from the database
/// </summary>
public record Dht22DataRequest (int DbId, string JsonString, Dht22SensorResponse Dht22Sensor)
	: RequestResponseBase, IRequest { }

/// <summary>
/// Requests to add a new Dht22Data point to the database
/// </summary>
public record Dht22DataNewRequest (string JsonString, Dht22SensorResponse Dht22Sensor)
	: RequestResponseBase, IRequest { }

/// <summary>
/// Requests to add a new Dht22Data point to the database
/// </summary>
public record Dht22AddDataToSensorRequest (int SensorDbId, string JsonString)
	: RequestResponseBase, IRequest { }