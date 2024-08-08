using LabAutomata.DataAccess.request;
using LabAutomata.DataAccess.response;
using LabAutomata.Db.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace LabAutomata.DataAccess.common {
	internal static class ExtensionMethods {
		#region DHT22DATA

		public static Dht22Data ToDbModel (this Dht22DataRequest request) {
			return new Dht22Data() {
				Id = request.DbId,
				Dht22SensorId = request.Dht22Sensor.Id,
				JsonString = request.JsonString,
				Dht22Sensor = request.Dht22Sensor
			};
		}

		public static Dht22Data ToDbModel (this Dht22DataNewRequest request) {
			return new Dht22Data() {
				JsonString = request.JsonString,
				Dht22SensorId = request.Dht22Sensor.Id,
				Dht22Sensor = request.Dht22Sensor
			};
		}

		public static Dht22DataResponse ToResponse (this EntityEntry<Dht22Data> entityEntry) {
			var e = entityEntry.Entity;
			return new Dht22DataResponse(e.Id, e.JsonString, e.Dht22Sensor, entityEntry.State);
		}

		public static Dht22DataResponse ToResponse (this Dht22Data data, EntityState state) {
			return new Dht22DataResponse(data.Id, data.JsonString, data.Dht22Sensor, state);
		}

		#endregion

		#region DHT22SENSOR

		public static Dht22Sensor ToDbModel (this Dht22SensorNewRequest request) {
			return new Dht22Sensor() {
				Name = request.Name,
				Location = request.Location.ToDbModel(),
				Description = request.Description,
				Data = []
			};
		}

		public static Dht22Sensor ToDbModel (this Dht22SensorRequest request) {
			return new Dht22Sensor() {
				Id = request.DbId,
				Name = request.Name,
				Description = request.Description,
				Location = request.Location.ToDbModel(),
				Data = request.Data
			};
		}

		// this method will allocate a new list in order to convert the entry.Data to 
		public static Dht22SensorResponse ToResponse (this EntityEntry<Dht22Sensor> entityEntry) {
			var e = entityEntry.Entity;

			var data = e.Data?
				.Select(d => d.ToResponse(EntityState.Unchanged))
				.ToList();

			return new Dht22SensorResponse(
				e.Id,
				e.Name,
				e.Description,
				e.Location,
				data,
				entityEntry.State);
		}

		public static Dht22SensorUpsertResponse ToUpsertResponse (this EntityEntry<Dht22Sensor> entityEntry) {
			var e = entityEntry.Entity;

			var data = e.Data?
				.Select(d => d.ToResponse(EntityState.Unchanged))
				.ToList();

			return new Dht22SensorUpsertResponse(
				e.Id,
				e.Name,
				e.Description,
				e.Location,
				data,
				entityEntry.State == EntityState.Modified);
		}

		#endregion

		#region LOCATION

		public static Location ToDbModel (this LocationNewRequest request) {
			return new Location() {
				Name = request.Name,
				City = request.City,
				State = request.State,
				Address = request.Address,
				Country = request.Country
			};
		}
		public static Location ToDbModel (this LocationRequest request) {
			return new Location() {
				Id = request.DbId,
				Name = request.Name,
				City = request.City,
				State = request.State,
				Address = request.Address,
				Country = request.Country
			};
		}

		public static LocationRequest ToRequest (this Location location) {
			return new LocationRequest(
				location.Id,
				location.Name,
				location.Country,
				location.City,
				location.State,
				location.Address);
		}

		public static LocationResponse ToResponse (this Location location) {
			return new LocationResponse(
				location.Id,
				location.Name,
				location.Country,
				location.City,
				location.State,
				location.Address,
				EntityState.Unchanged);
		}

		public static LocationResponse ToResponse (this EntityEntry<Location> entityEntry) {
			var e = entityEntry.Entity;

			return new LocationResponse(
				e.Id,
				e.Name,
				e.Country,
				e.City,
				e.State,
				e.Address,
				entityEntry.State);
		}

		public static LocationUpsertResponse ToUpsertResponse (this EntityEntry<Location> entityEntry) {
			var e = entityEntry.Entity;

			return new LocationUpsertResponse(
				e.Id,
				e.Name,
				e.Country,
				e.City,
				e.State,
				e.Address,
				entityEntry.State == EntityState.Modified);
		}

		#endregion

		#region MANUFACTURER

		public static Manufacturer ToDbModel (this ManufacturerNewRequest request) {
			return new Manufacturer() {
				Name = request.Name,
				LocationId = request.Location.DbId,
				Location = request.Location.ToDbModel()
			};
		}

		public static Manufacturer ToDbModel (this ManufacturerRequest request) {
			return new Manufacturer() {
				Id = request.DbId,
				LocationId = request.Location.DbId,
				Name = request.Name,
				Location = request.Location.ToDbModel()
			};
		}

		public static ManufacturerResponse ToResponse (this EntityEntry<Manufacturer> entityEntry) {
			var e = entityEntry.Entity;

			return new ManufacturerResponse(
				e.Id,
				e.Name,
				e.Location.ToResponse(),
				entityEntry.State);
		}

		public static ManufacturerUpsertResponse ToUpsertResponse (this EntityEntry<Manufacturer> entityEntry) {
			var e = entityEntry.Entity;

			return new ManufacturerUpsertResponse(
				e.Id,
				e.Name,
				e.Location.ToResponse(),
				entityEntry.State == EntityState.Modified);
		}

		#endregion

		#region WORKREQUEST

		public static WorkRequest ToDbModel (this WorkRequestNewRequest request) {
			return new WorkRequest() {
				Name = request.Name,
				RequestId = request.RequestId,
				Program = request.Program,
				Description = request.Description,
				Started = request.Started,
				Finished = request.Finished
			};
		}

		public static WorkRequest ToDbModel (this WorkRequestRequest request) {
			return new WorkRequest() {
				Id = request.Id,
				Name = request.Name,
				RequestId = request.RequestId,
				Program = request.Program,
				Description = request.Description,
				Started = request.Started,
				Finished = request.Finished
			};
		}

		public static WorkRequestResponse ToResponse (this EntityEntry<WorkRequest> entityEntry) {
			var e = entityEntry.Entity;

			return new WorkRequestResponse(
				e.Id,
				e.Name,
				e.RequestId,
				e.Name,
				e.Description,
				e.Started,
				e.Finished,
				entityEntry.State);
		}

		public static WorkRequestUpsertResponse ToUpsertResponse (this EntityEntry<WorkRequest> entityEntry) {
			var e = entityEntry.Entity;

			return new WorkRequestUpsertResponse(
				e.Id,
				e.Name,
				e.RequestId,
				e.Name,
				e.Description,
				e.Started,
				e.Finished,
				entityEntry.State == EntityState.Modified);
		}


		#endregion

		#region WORKSTATION

		public static WorkstationResponse ToResponse (this Workstation workstation) {
			LocationResponse location = workstation.Location != null
				? workstation.Location.ToResponse()
				: LocationResponse.Empty;

			return new WorkstationResponse(
				workstation.Id,
				workstation.Name,
				workstation.StationNumber,
				workstation.Description,
				workstation.Created,
				location,
				EntityState.Unchanged);
		}

		#endregion
	}
}