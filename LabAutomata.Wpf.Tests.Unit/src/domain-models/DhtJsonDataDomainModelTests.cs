using FluentAssertions;
using LabAutomata.Db.models;
using LabAutomata.Wpf.Library.domain_models;

namespace LabAutomata.Wpf.Tests.Unit.domain_models {
	public class DhtJsonDataDomainModelTests {
		[Fact]
		public void Create_ShouldReturnDhtJsonDataWithCorrectProperties () {
			// Arrange
			int id = 1;
			string jsonString = "{\"temperature\": 25, \"humidity\": 50}";
			int dhtSensorId = 2;
			DhtSensor dhtSensor = new DhtSensor();

			DhtJsonDataDomainModel domainModel = new DhtJsonDataDomainModel(id, jsonString, dhtSensorId, dhtSensor);

			// Act
			DhtJsonData result = domainModel.Create();

			// Assert
			result.Id.Should().Be(id);
			result.JsonString.Should().Be(jsonString);
			result.DhtSensorId.Should().Be(dhtSensorId);
			result.DhtSensor.Should().Be(dhtSensor);
		}

		[Fact]
		public void Validate_ShouldThrowArgumentNullException_WhenJsonStringIsNull () {
			// Arrange
			DhtJsonDataDomainModel domainModel = new DhtJsonDataDomainModel();
			domainModel.JsonString = null;

			// Act
			var action = new Action(() => domainModel.Validate());

			// Assert
			action.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'JsonString')");
		}

		[Fact]
		public void Validate_ShouldThrowArgumentException_WhenDhtSensorIdIsZero () {
			// Arrange
			DhtJsonDataDomainModel domainModel = new DhtJsonDataDomainModel();
			domainModel.DhtSensorId = 0;

			// Act
			var action = new Action(() => domainModel.Validate());

			// Assert
			action.Should().Throw<ArgumentException>().WithMessage("Value cannot be null. (Parameter 'JsonString')");
		}

		[Fact]
		public void Validate_ShouldThrowArgumentNullException_WhenDhtSensorIsNull () {
			// Arrange
			DhtJsonDataDomainModel domainModel = new DhtJsonDataDomainModel();
			domainModel.DhtSensor = null;

			// Act
			var action = new Action(() => domainModel.Validate());

			// Assert
			action.Should().Throw<ArgumentNullException>().WithMessage("Value cannot be null. (Parameter 'JsonString')");
		}
	}
}
