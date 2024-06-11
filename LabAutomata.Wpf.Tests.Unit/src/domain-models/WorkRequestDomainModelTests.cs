using FluentAssertions;
using LabAutomata.Db.models;
using LabAutomata.Wpf.Library.common;
using LabAutomata.Wpf.Library.domain_models;
using System.Collections.ObjectModel;

namespace LabAutomata.Wpf.Tests.Unit.domain_models {

	public class WorkRequestDomainModelTests {
		private readonly WorkRequestDomainModel _sut = new();

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
		public void Name_Setter_Should_AddErrorWhenValueIsNullOrEmpty () {
			// Arrange

			// Act
			_sut.Name = null;

			// Assert
			var errors = (List<string>)_sut.GetErrors(nameof(WorkRequestDomainModel.Name));
			errors.Should().Contain(WpfLibC.Msg.WrDomainNameIsNull);
		}

		[Fact]
		public void Program_Setter_Should_SetValueAndNotifyPropertyChanged () {
			// Arrange
			var propertyName = string.Empty;
			_sut.PropertyChanged += (sender, args) => propertyName = args.PropertyName;

			// Act
			_sut.Program = "Test Program";

			// Assert
			_sut.Program.Should().Be("Test Program");
			propertyName.Should().Be(nameof(_sut.Program));
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
		public void StartDate_Setter_Should_SetValueAndNotifyPropertyChanged () {
			// Arrange
			var propertyName = string.Empty;
			_sut.PropertyChanged += (sender, args) => propertyName = args.PropertyName;
			var startDate = new DateTime(2024, 1, 1);

			// Act
			_sut.StartDate = startDate;

			// Assert
			_sut.StartDate.Should().Be(startDate);
			propertyName.Should().Be(nameof(_sut.StartDate));
		}

		[Fact]
		public void ObsGetErrors_Setter_Should_SetValueAndNotifyPropertyChanged () {
			// Arrange
			var propertyName = string.Empty;
			var sut = new WorkRequestDomainModel();
			sut.PropertyChanged += (sender, args) => propertyName = args.PropertyName;

			// Act
			var errors = new List<string> { "Error 1", "Error 2" };
			sut.ObsGetErrors = errors;

			// Assert
			sut.ObsGetErrors.Should().BeEquivalentTo(errors);
			propertyName.Should().Be(nameof(sut.ObsGetErrors));
		}

		[Fact]
		public void Reset_ShouldResetPropertiesToDefaultValues_WhenCalled () {
			// Arrange
			_sut.Name = "Test SensorName";
			_sut.Program = "Test Program";
			_sut.Description = "Test Description";
			_sut.StartDate = DateTime.Now;
			_sut.Tests = new ObservableCollection<Test> { new Test() };

			// Act
			_sut.Reset();

			// Assert
			_sut.Name.Should().BeEmpty();
			_sut.Program.Should().BeEmpty();
			_sut.Description.Should().BeEmpty();
			_sut.StartDate.Should().BeNull();
			_sut.Tests.Should().BeEmpty();
		}

		[Fact]
		public void Create_ShouldReturnNewWorkRequestWithSameProperties_WhenCalled () {
			// Arrange
			_sut.Name = "Test SensorName";
			_sut.Program = "Test Program";
			_sut.Description = "Test Description";
			_sut.StartDate = DateTime.Now;
			_sut.Manufacturer = new Manufacturer();
			_sut.Tests = new ObservableCollection<Test>();

			// Act
			var workRequest = _sut.Create();

			// Assert
			workRequest.Name.Should().BeEquivalentTo(_sut.Name);
			workRequest.Program.Should().BeEquivalentTo(_sut.Program);
			workRequest.Description.Should().BeEquivalentTo(_sut.Description);
			workRequest.Started.Should().Be(_sut.StartDate);
			workRequest.Manufacturer.Should().NotBeNull();
			workRequest.Tests.Should().BeEquivalentTo(_sut.Tests);
		}

		[Fact]
		public void Validate_ShouldThrowArgumentNullException_WhenNameOrProgramAreNullOrWhiteSpace () {
			// Arrange
			_sut.Name = null;
			_sut.Program = null;

			// Act
			Action act = () => _sut.Validate();

			// Assert
			act.Should().Throw<ArgumentNullException>();
		}
	}
}