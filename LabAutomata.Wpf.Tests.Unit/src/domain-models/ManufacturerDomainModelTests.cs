using FluentAssertions;
using LabAutomata.Db.models;
using LabAutomata.Wpf.Library.domain_models;
using System.Collections.ObjectModel;

namespace LabAutomata.Wpf.Tests.Unit.domain_models {

	public class ManufacturerDomainModelTests {
		private readonly ManufacturerDomainModel _sut = new();

		[Fact]
		public void Name_Setter_Should_SetValueAndNotifyPropertyChanged () {
			// Arrange
			var propertyName = string.Empty;
			_sut.PropertyChanged += (sender, args) => propertyName = args.PropertyName;

			// Act
			_sut.Name = "Test Name";

			// Assert
			_sut.Name.Should().Be("Test Name");
			propertyName.Should().Be(nameof(_sut.Name));
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
		public void WorkRequests_Setter_Should_SetValueAndNotifyPropertyChanged () {
			// Arrange
			var propertyName = string.Empty;
			_sut.PropertyChanged += (sender, args) => propertyName = args.PropertyName;
			var workRequests = new ObservableCollection<WorkRequest> { new WorkRequest() };

			// Act
			_sut.WorkRequests = workRequests;

			// Assert
			_sut.WorkRequests.Should().BeEquivalentTo(workRequests);
			propertyName.Should().Be(nameof(_sut.WorkRequests));
		}

		[Fact]
		public void Create_ShouldReturnNewManufacturerWithSameProperties_WhenCalled () {
			// Arrange
			_sut.Name = "Test Name";
			_sut.LocationId = 1;
			_sut.Location = new Location();
			_sut.WorkRequests = new ObservableCollection<WorkRequest> { new WorkRequest() };

			// Act
			var manufacturer = _sut.Create();

			// Assert
			manufacturer.Name.Should().Be(_sut.Name);
			manufacturer.LocationId.Should().Be(_sut.LocationId);
			manufacturer.Location.Should().Be(_sut.Location);
			manufacturer.WorkRequests.Should().BeEquivalentTo(_sut.WorkRequests);
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
	}
}