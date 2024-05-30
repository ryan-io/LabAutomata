using FluentAssertions;
using LabAutomata.Wpf.Library.domain_models;

namespace LabAutomata.Wpf.Tests.Unit.domain_models {
    public class LocationDomainModelTests {
        private readonly LocationDomainModel _sut = new();

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

        [Fact]
        public void Create_ShouldReturnNewLocationWithSameProperties_WhenCalled () {
            // Arrange
            _sut.Name = "Test Name";
            _sut.Address = "Test Address";
            _sut.City = "Test City";
            _sut.State = "Test State";
            _sut.Country = "Test Country";

            // Act
            var location = _sut.Create();

            // Assert
            location.Name.Should().Be(_sut.Name);
            location.Address.Should().Be(_sut.Address);
            location.City.Should().Be(_sut.City);
            location.State.Should().Be(_sut.State);
            location.Country.Should().Be(_sut.Country);
        }

        [Fact]
        public void Validate_ShouldThrowArgumentNullException_WhenNameOrAddressOrCityOrStateOrCountryAreNullOrWhiteSpace () {
            // Arrange
            _sut.Name = null;
            _sut.Address = null;
            _sut.City = null;
            _sut.State = null;
            _sut.Country = null;

            // Act
            Action act = () => _sut.Validate();

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }
    }
}
