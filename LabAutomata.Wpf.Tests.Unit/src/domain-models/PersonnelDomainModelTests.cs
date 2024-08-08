using FluentAssertions;
using LabAutomata.DataAccess.response;
using LabAutomata.Wpf.Library.domain_models;
using Microsoft.EntityFrameworkCore;

namespace LabAutomata.Wpf.Tests.Unit.domain_models {

	public class PersonnelDomainModelTests {
		private readonly PersonnelDomainModel _sut = new(new PersonnelResponse(
			1,
			"FirstName",
			"LastName",
			"email@email.com",
			LocationResponse.Empty,
			EntityState.Unchanged));

		[Fact]
		public void FirstName_Setter_Should_SetValueAndNotifyPropertyChanged () {
			// Arrange
			var propertyName = string.Empty;
			_sut.PropertyChanged += (sender, args) => propertyName = args.PropertyName;

			// Act
			_sut.FirstName = "Test FirstName";

			// Assert
			_sut.FirstName.Should().Be("Test FirstName");
			propertyName.Should().Be(nameof(_sut.FirstName));
		}

		[Fact]
		public void LastName_Setter_Should_SetValueAndNotifyPropertyChanged () {
			// Arrange
			var propertyName = string.Empty;
			_sut.PropertyChanged += (sender, args) => propertyName = args.PropertyName;

			// Act
			_sut.LastName = "Test LastName";

			// Assert
			_sut.LastName.Should().Be("Test LastName");
			propertyName.Should().Be(nameof(_sut.LastName));
		}

		[Fact]
		public void Email_Setter_Should_SetValueAndNotifyPropertyChanged () {
			// Arrange
			var propertyName = string.Empty;
			_sut.PropertyChanged += (sender, args) => propertyName = args.PropertyName;

			// Act
			_sut.Email = "Test Email";

			// Assert
			_sut.Email.Should().Be("Test Email");
			propertyName.Should().Be(nameof(_sut.Email));
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