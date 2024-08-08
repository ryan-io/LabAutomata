using FluentAssertions;
using LabAutomata.DataAccess.response;
using LabAutomata.Db.models;
using LabAutomata.Wpf.Library.common;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.Wpf.Tests.Unit.domain_models {
	public class Dht22DataDomainTests {

		[Fact]
		public void SensorName_ShouldNotBeNullWhitespaceOrEmpty () {
			// Arrange
			var domain = GetResponse().ToDomain();

			// Act
			var isEmpty = string.IsNullOrWhiteSpace(domain.SensorName);

			// Assert
			isEmpty.Should().BeFalse();
		}

		[Fact]
		public void Data_ShouldNotBeNull () {
			// Arrange
			var domain = GetResponse().ToDomain();

			// Act
			var isDataNull = domain.Data == null;

			// Assert
			isDataNull.Should().BeFalse();
		}

		static Dht22SensorResponse GetResponse () {
			int id = 1;
			string jsonString = "{\"temperature\": 25, \"humidity\": 50}";
			int dhtSensorId = 2;
			string name = "testName";
			string description = "testDesc";

			Location location = new Location() {
				Id = 0,
				Name = "testloc",
				Address = "testadd",
				City = "testcity",
				Country = "testcnt",
				State = "teststate"
			};

			return new Dht22SensorResponse(
				dhtSensorId,
				name,
				description,
				location,
				new List<Dht22DataResponse>(),
				EntityState.Unchanged
			);
		}
	}
}