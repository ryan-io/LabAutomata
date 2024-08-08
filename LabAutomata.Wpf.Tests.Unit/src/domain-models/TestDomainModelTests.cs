//using FluentAssertions;

//namespace LabAutomata.Wpf.Tests.Unit.domain_models {

//	public class TestDomainModelTests {
//		private readonly TestDomain _sut = new();

//		[Fact]
//		public void Name_Setter_Should_SetValueAndNotifyPropertyChanged () {
//			// Arrange
//			var propertyName = string.Empty;
//			_sut.PropertyChanged += (sender, args) => propertyName = args.PropertyName;

//			// Act
//			_sut.Name = "Test SensorName";

//			// Assert
//			_sut.Name.Should().Be("Test SensorName");
//			propertyName.Should().Be(nameof(_sut.Name));
//		}

//		[Fact]
//		public void WrId_Setter_Should_SetValueAndNotifyPropertyChanged () {
//			// Arrange
//			var propertyName = string.Empty;
//			_sut.PropertyChanged += (sender, args) => propertyName = args.PropertyName;

//			// Act
//			_sut.WrId = 1;

//			// Assert
//			_sut.WrId.Should().Be(1);
//			propertyName.Should().Be(nameof(_sut.WrId));
//		}

//		[Fact]
//		public void Create_ShouldReturnNewTestWithSameProperties_WhenCalled () {
//			// Arrange
//			_sut.Name = "Test SensorName";
//			_sut.WrId = 1;
//			_sut.InstanceId = 2;
//			_sut.TypeId = 3;
//			_sut.LocationId = 4;
//			_sut.OperatorId = 5;
//			_sut.Started = DateTime.Now;
//			_sut.Ended = DateTime.Now;

//			// Act
//			var test = _sut.Create();

//			// Assert
//			test.Name.Should().Be(_sut.Name);
//			test.WrId.Should().Be(_sut.WrId);
//			test.InstanceId.Should().Be(_sut.InstanceId);
//			test.TypeId.Should().Be(_sut.TypeId);
//			test.LocationId.Should().Be(_sut.LocationId);
//			test.OperatorId.Should().Be(_sut.OperatorId);
//			test.Started.Should().Be(_sut.Started);
//			test.Ended.Should().Be(_sut.Ended);
//		}

//		[Fact]
//		public void Validate_ShouldThrowArgumentNullException_WhenNameIsNullOrWhiteSpace () {
//			// Arrange
//			_sut.Name = default;

//			// Act
//			Action act = () => _sut.Validate();

//			// Assert
//			act.Should().Throw<ArgumentNullException>();
//		}

//		[Fact]
//		public void Validate_ShouldThrowArgumentException_WhenWrIdIsLessThanOrEqualToZero () {
//			// Arrange
//			_sut.WrId = 0;

//			// Act
//			Action act = () => _sut.Validate();

//			// Assert
//			act.Should().Throw<ArgumentException>();
//		}
//	}
//}