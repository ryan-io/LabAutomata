//using FluentAssertions;
//using LabAutomata.Db.models;
//using LabAutomata.Wpf.Library.domain_models;

//namespace LabAutomata.Wpf.Tests.Unit.domain_models {

//	public class PersonnelDomainModelTests {
//		private readonly PersonnelDomainModel _sut = new();

//		[Fact]
//		public void FirstName_Setter_Should_SetValueAndNotifyPropertyChanged () {
//			// Arrange
//			var propertyName = string.Empty;
//			_sut.PropertyChanged += (sender, args) => propertyName = args.PropertyName;

//			// Act
//			_sut.FirstName = "Test FirstName";

//			// Assert
//			_sut.FirstName.Should().Be("Test FirstName");
//			propertyName.Should().Be(nameof(_sut.FirstName));
//		}

//		[Fact]
//		public void LastName_Setter_Should_SetValueAndNotifyPropertyChanged () {
//			// Arrange
//			var propertyName = string.Empty;
//			_sut.PropertyChanged += (sender, args) => propertyName = args.PropertyName;

//			// Act
//			_sut.LastName = "Test LastName";

//			// Assert
//			_sut.LastName.Should().Be("Test LastName");
//			propertyName.Should().Be(nameof(_sut.LastName));
//		}

//		[Fact]
//		public void Email_Setter_Should_SetValueAndNotifyPropertyChanged () {
//			// Arrange
//			var propertyName = string.Empty;
//			_sut.PropertyChanged += (sender, args) => propertyName = args.PropertyName;

//			// Act
//			_sut.Email = "Test Email";

//			// Assert
//			_sut.Email.Should().Be("Test Email");
//			propertyName.Should().Be(nameof(_sut.Email));
//		}

//		[Fact]
//		public void LocationId_Setter_Should_SetValueAndNotifyPropertyChanged () {
//			// Arrange
//			var propertyName = string.Empty;
//			_sut.PropertyChanged += (sender, args) => propertyName = args.PropertyName;

//			// Act
//			_sut.LocationId = 1;

//			// Assert
//			_sut.LocationId.Should().Be(1);
//			propertyName.Should().Be(nameof(_sut.LocationId));
//		}

//		[Fact]
//		public void Location_Setter_Should_SetValueAndNotifyPropertyChanged () {
//			// Arrange
//			var propertyName = string.Empty;
//			_sut.PropertyChanged += (sender, args) => propertyName = args.PropertyName;
//			var location = new Location();

//			// Act
//			_sut.Location = location;

//			// Assert
//			_sut.Location.Should().Be(location);
//			propertyName.Should().Be(nameof(_sut.Location));
//		}

//		[Fact]
//		public void Create_ShouldReturnNewPersonnelWithSameProperties_WhenCalled () {
//			// Arrange
//			_sut.FirstName = "Test FirstName";
//			_sut.LastName = "Test LastName";
//			_sut.Email = "Test Email";
//			_sut.LocationId = 1;
//			_sut.Location = new Location();

//			// Act
//			var personnel = _sut.Create();

//			// Assert
//			personnel.FirstName.Should().Be(_sut.FirstName);
//			personnel.LastName.Should().Be(_sut.LastName);
//			personnel.Email.Should().Be(_sut.Email);
//			personnel.LocationId.Should().Be(_sut.LocationId);
//			personnel.Location.Should().Be(_sut.Location);
//		}

//		[Fact]
//		public void Validate_ShouldThrowArgumentNullException_WhenFirstNameOrLastNameOrEmailOrLocationAreNullOrWhiteSpace () {
//			// Arrange
//			_sut.FirstName = null;
//			_sut.LastName = null;
//			_sut.Email = null;
//			_sut.Location = null;

//			// Act
//			Action act = () => _sut.Validate();

//			// Assert
//			act.Should().Throw<ArgumentNullException>();
//		}
//	}
//}