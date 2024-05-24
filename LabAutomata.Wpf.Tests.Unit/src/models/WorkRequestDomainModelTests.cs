using FluentAssertions;
using LabAutomata.Wpf.Library.common;
using LabAutomata.Wpf.Library.models;

namespace LabAutomata.Wpf.Tests.Unit.models {
    public class WorkRequestDomainModelTests
    {
        private readonly WorkRequestDomainModel _sut = new();

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
    }
}