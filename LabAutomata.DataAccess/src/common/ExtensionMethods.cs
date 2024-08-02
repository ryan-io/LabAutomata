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
				Id = request.Id,
				JsonString = request.JsonString,
				Dht22Sensor = request.Dht22Sensor
			};
		}

		public static Dht22Data ToDbModel (this Dht22DataNewRequest request) {
			return new Dht22Data() {
				JsonString = request.JsonString,
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
				Description = request.Description,
				Data = []
			};
		}

		public static Dht22Sensor ToDbModel (this Dht22SensorRequest request) {
			return new Dht22Sensor() {
				Id = request.Id,
				Name = request.Name,
				Description = request.Description,
				Data = request.Data
			};
		}

		// this method will allocate a new list in order to convert the entry.Data to 
		public static Dht22SensorResponse ToResponse (this EntityEntry<Dht22Sensor> entityEntry) {
			var e = entityEntry.Entity;

			var data = e.Data?
				.Select(d => d.ToResponse(EntityState.Unchanged))
				.ToList();

			return new Dht22SensorResponse(e.Id, e.Name, e.Description, data, entityEntry.State);
		}

		#endregion
	}
}
