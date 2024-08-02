﻿using LabAutomata.DataAccess.common;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.DataAccess.response;

public record Dht22SensorResponse (
	int DbId,
	string Name,
	string? Description,
	ICollection<Dht22DataResponse>? Data,
	EntityState State)
	: RequestResponseBase { }

public record Dht22SensorUpsertResponse (
	int DbId,
	string Name,
	string? Description,
	ICollection<Dht22DataResponse>? Data,
	bool WasUpdated)
	: RequestResponseBase { }