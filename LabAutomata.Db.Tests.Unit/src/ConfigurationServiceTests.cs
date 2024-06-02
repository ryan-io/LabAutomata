using FluentAssertions;
using LabAutomata.Db.common;

namespace LabAutomata.Db.Tests.Unit {
	public class ConfigurationServiceTests {
		private readonly ConfigurationService _sut = new();

		[Fact]
		public void Create_ShouldReturnConfiguration_WhenCalledWithValidType () {
			// Arrange

			// Act
			var configuration = _sut.Create<ConfigurationServiceTests>();

			// Assert
			configuration.Should().NotBeNull();
		}
	}
}
