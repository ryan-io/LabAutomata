using FluentAssertions;
using LabAutomata.DataAccess.response;
using LabAutomata.Wpf.Library.domain_models;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.Wpf.Tests.Unit.domain_models {

	public class ManufacturerDomainModelTests {
		private readonly ManufacturerDomainModel _sut = new(
			new ManufacturerResponse(
				1,
				"test-man",
				LocationResponse.Empty,
				EntityState.Unchanged)
			);

		[Fact]
		public void Name_Setter_Should_SetValueAndNotifyPropertyChanged () {
			// Arrange
			var propertyName = string.Empty;
			_sut.PropertyChanged += (sender, args) => propertyName = args.PropertyName;

			// Act
			_sut.Name = "Test SensorName";

			// Assert
			_sut.Name.Should().Be("Test SensorName");
			propertyName.Should().Be(nameof(_sut.Name));
		}

		[Fact]
		public void Location_Setter_Should_SetValueAndNotifyPropertyChanged () {
			// Arrange
			var propertyName = string.Empty;
			_sut.PropertyChanged += (sender, args) => propertyName = args.PropertyName;
			var location = LocationResponse.Empty;

			// Act
			_sut.Location = location;

			// Assert
			_sut.Location.Should().Be(location);
			propertyName.Should().Be(nameof(_sut.Location));
		}
	}
}