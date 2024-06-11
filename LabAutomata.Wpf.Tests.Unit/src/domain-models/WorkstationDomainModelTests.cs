using FluentAssertions;
using LabAutomata.Db.models;
using LabAutomata.Wpf.Library.domain_models;
using System.Collections.ObjectModel;

namespace LabAutomata.Wpf.Tests.Unit.domain_models {

	public class WorkstationDomainModelTests {
		private readonly WorkstationDomainModel _sut = new();

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
		public void StationNumber_Setter_Should_SetValueAndNotifyPropertyChanged () {
			// Arrange
			var propertyName = string.Empty;
			_sut.PropertyChanged += (sender, args) => propertyName = args.PropertyName;

			// Act
			_sut.StationNumber = 1;

			// Assert
			_sut.StationNumber.Should().Be(1);
			propertyName.Should().Be(nameof(_sut.StationNumber));
		}

		[Fact]
		public void LocationId_Setter_Should_SetValueAndNotifyPropertyChanged () {
			// Arrange
			var propertyName = string.Empty;
			_sut.PropertyChanged += (sender, args) => propertyName = args.PropertyName;

			// Act
			_sut.LocationId = 1;

			// Assert
			_sut.LocationId.Should().Be(1);
			propertyName.Should().Be(nameof(_sut.LocationId));
		}

		[Fact]
		public void Location_Setter_Should_SetValueAndNotifyPropertyChanged () {
			// Arrange
			var propertyName = string.Empty;
			_sut.PropertyChanged += (sender, args) => propertyName = args.PropertyName;
			var location = new Location();

			// Act
			_sut.Location = location;

			// Assert
			_sut.Location.Should().Be(location);
			propertyName.Should().Be(nameof(_sut.Location));
		}

		[Fact]
		public void Tests_Setter_Should_SetValueAndNotifyPropertyChanged () {
			// Arrange
			var propertyName = string.Empty;
			_sut.PropertyChanged += (sender, args) => propertyName = args.PropertyName;
			var tests = new ObservableCollection<Test> { new Test() };

			// Act
			_sut.Tests = tests;

			// Assert
			_sut.Tests.Should().BeEquivalentTo(tests);
			propertyName.Should().Be(nameof(_sut.Tests));
		}

		[Fact]
		public void Description_Setter_Should_SetValueAndNotifyPropertyChanged () {
			// Arrange
			var propertyName = string.Empty;
			_sut.PropertyChanged += (sender, args) => propertyName = args.PropertyName;

			// Act
			_sut.Description = "Test Description";

			// Assert
			_sut.Description.Should().Be("Test Description");
			propertyName.Should().Be(nameof(_sut.Description));
		}

		[Fact]
		public void Create_ShouldReturnNewWorkstationWithSameProperties_WhenCalled () {
			// Arrange
			_sut.Name = "Test SensorName";
			_sut.StationNumber = 1;
			_sut.LocationId = 1;
			_sut.Location = new Location();
			_sut.Tests = new ObservableCollection<Test> { new Test() };
			_sut.Description = "Test Description";

			// Act
			var workstation = _sut.Create();

			// Assert
			workstation.Name.Should().Be(_sut.Name);
			workstation.StationNumber.Should().Be(_sut.StationNumber);
			workstation.LocationId.Should().Be(_sut.LocationId);
			workstation.Location.Should().Be(_sut.Location);
			workstation.Tests.Should().BeEquivalentTo(_sut.Tests);
			workstation.Description.Should().Be(_sut.Description);
		}

		[Fact]
		public void Validate_ShouldThrowArgumentNullException_WhenNameOrLocationAreNullOrWhiteSpace () {
			// Arrange
			_sut.Name = null;
			_sut.Location = null;

			// Act
			Action act = () => _sut.Validate();

			// Assert
			act.Should().Throw<ArgumentNullException>();
		}

		[Fact]
		public void Validate_ShouldThrowArgumentException_WhenStationNumberOrLocationIdAreLessThanOrEqualToZero () {
			// Arrange
			_sut.StationNumber = 0;
			_sut.LocationId = 0;

			// Act
			Action act = () => _sut.Validate();

			// Assert
			act.Should().Throw<ArgumentException>();
		}
	}
}