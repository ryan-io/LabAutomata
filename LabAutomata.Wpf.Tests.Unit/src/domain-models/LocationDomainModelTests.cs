using FluentAssertions;
using LabAutomata.Wpf.Library.domain_models;

namespace LabAutomata.Wpf.Tests.Unit.domain_models {

	public class LocationDomainModelTests {
		private readonly LocationDomainModel _sut;

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
		public void Address_Setter_Should_SetValueAndNotifyPropertyChanged () {
			// Arrange
			var propertyName = string.Empty;
			_sut.PropertyChanged += (sender, args) => propertyName = args.PropertyName;

			// Act
			_sut.Address = "Test Address";

			// Assert
			_sut.Address.Should().Be("Test Address");
			propertyName.Should().Be(nameof(_sut.Address));
		}

		[Fact]
		public void City_Setter_Should_SetValueAndNotifyPropertyChanged () {
			// Arrange
			var propertyName = string.Empty;
			_sut.PropertyChanged += (sender, args) => propertyName = args.PropertyName;

			// Act
			_sut.City = "Test City";

			// Assert
			_sut.City.Should().Be("Test City");
			propertyName.Should().Be(nameof(_sut.City));
		}

		[Fact]
		public void State_Setter_Should_SetValueAndNotifyPropertyChanged () {
			// Arrange
			var propertyName = string.Empty;
			_sut.PropertyChanged += (sender, args) => propertyName = args.PropertyName;

			// Act
			_sut.State = "Test State";

			// Assert
			_sut.State.Should().Be("Test State");
			propertyName.Should().Be(nameof(_sut.State));
		}

		[Fact]
		public void Country_Setter_Should_SetValueAndNotifyPropertyChanged () {
			// Arrange
			var propertyName = string.Empty;
			_sut.PropertyChanged += (sender, args) => propertyName = args.PropertyName;

			// Act
			_sut.Country = "Test Country";

			// Assert
			_sut.Country.Should().Be("Test Country");
			propertyName.Should().Be(nameof(_sut.Country));
		}
	}
}