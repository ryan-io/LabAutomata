using FluentAssertions;
using LabAutomata.Wpf.Library.domain_models;

namespace LabAutomata.Wpf.Tests.Unit.domain_models {

	public class TestTypeDomainModelTests {
		private readonly TestTypeDomainModel _sut = new();

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
		public void BitId_Setter_Should_SetValueAndNotifyPropertyChanged () {
			// Arrange
			var propertyName = string.Empty;
			_sut.PropertyChanged += (sender, args) => propertyName = args.PropertyName;

			// Act
			_sut.BitId = 1;

			// Assert
			_sut.BitId.Should().Be(1);
			propertyName.Should().Be(nameof(_sut.BitId));
		}

		[Fact]
		public void Create_ShouldReturnNewTestTypeWithSameProperties_WhenCalled () {
			// Arrange
			_sut.Name = "Test Name";
			_sut.BitId = 1;

			// Act
			var testType = _sut.Create();

			// Assert
			testType.Name.Should().Be(_sut.Name);
		}

		[Fact]
		public void Validate_ShouldThrowArgumentNullException_WhenNameIsNullOrWhiteSpace () {
			// Arrange
			_sut.Name = null;

			// Act
			Action act = () => _sut.Validate();

			// Assert
			act.Should().Throw<ArgumentNullException>();
		}

		[Fact]
		public void Validate_ShouldThrowArgumentException_WhenBitIdIsLessThanOrEqualToZero () {
			// Arrange
			_sut.BitId = 0;

			// Act
			Action act = () => _sut.Validate();

			// Assert
			act.Should().Throw<ArgumentException>();
		}
	}
}