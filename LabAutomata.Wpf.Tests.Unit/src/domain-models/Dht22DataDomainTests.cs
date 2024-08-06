using FluentAssertions;
using LabAutomata.Db.models;
using LabAutomata.Wpf.Library.domain_models;

namespace LabAutomata.Wpf.Tests.Unit.domain_models {
	public class Dht22DataDomainTests {
		[Fact]
		public void Create_ShouldReturnDhtJsonDataWithCorrectProperties () {
			// Arrange
			int id = 1;
			string jsonString = "{\"temperature\": 25, \"humidity\": 50}";
			int dhtSensorId = 2;
			Dht22Sensor dht22Sensor = new Dht22Sensor() {
				Name = "test",
				Location = new Location() {
					Id = 0,
					Name = "testloc",
					Address = "testadd",
					City = "testcity",
					Country = "testcnt",
					State = "teststate"
				}
			};

			Dht22DataDomain domain = new Dht22DataDomain(id, jsonString, dhtSensorId, dht22Sensor);

			// Act
			Dht22Data result = domain.Create();

			// Assert
			result.Id.Should().Be(id);
			result.JsonString.Should().Be(jsonString);
			result.Dht22Sensor.Id.Should().Be(dhtSensorId);
			result.Dht22Sensor.Should().Be(dht22Sensor);
		}

		[Fact]
		public void Validate_ShouldThrowArgumentNullException_WhenJsonStringIsNull () {
			// Arrange
			Dht22DataDomain domain = new Dht22DataDomain();
			domain.JsonString = null;

			// Act
			var action = new Action(() => domain.Validate());

			// Assert
			action.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'JsonString')");
		}

		[Fact]
		public void Validate_ShouldThrowArgumentException_WhenDhtSensorIdIsZero () {
			// Arrange
			Dht22DataDomain domain = new Dht22DataDomain();
			domain.DhtSensorId = 0;

			// Act
			var action = new Action(() => domain.Validate());

			// Assert
			action.Should().Throw<ArgumentException>().WithMessage("Value cannot be null. (Parameter 'JsonString')");
		}

		[Fact]
		public void Validate_ShouldThrowArgumentNullException_WhenDhtSensorIsNull () {
			// Arrange
			Dht22DataDomain domain = new Dht22DataDomain();
			domain.Dht22Sensor = null;

			// Act
			var action = new Action(() => domain.Validate());

			// Assert
			action.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'JsonString')");
		}
	}
}
