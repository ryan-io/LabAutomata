﻿using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.Db.common;

public interface IDhtSensorSet {
	DbSet<Dht22Sensor> DhtSensors { get; }
}

public interface ILabPostgreSqlDbContext : IDhtSensorSet {
	DbSet<WorkRequest> WorkRequests { get; }
	DbSet<Workstation> Workstations { get; }
	DbSet<Personnel> Personnels { get; }
	DbSet<Equipment> Equipment { get; }
	DbSet<Test> Test { get; }
	DbSet<Manufacturer> Manufacturers { get; }
	DbSet<SeedJson> SeedJson { get; }
	DbSet<TestType> TestType { get; }
	DbSet<WorkstationType> WorkstationTypesType { get; }
	DbSet<Location> Location { get; }
	DbSet<Dht22Data> DhtJsonData { get; }
	PostgreSqlDbContext PostgreSqlDb { get; }
}