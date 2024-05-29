using FluentAssertions;
using LabAutomata.Db.common;
using LabAutomata.Db.models;
using LabAutomata.Db.repository;
using NSubstitute;

namespace LabAutomata.Db.Tests.Unit.repository {
    public class RepositoryTests {
        private readonly ILabPostgreSqlDbContext _dbContext = Substitute.For<ILabPostgreSqlDbContext>();
        private readonly IRepository<SteadyStateTemperatureTest> _repository = Substitute.For<IRepository<SteadyStateTemperatureTest>>();

        [Fact]
        public async Task Create_ShouldAddEntityToDatabase_WhenNoErrorIsThrown () {
            // Arrange
            var entity = new SteadyStateTemperatureTest();
            var cancellationToken = CancellationToken.None;
            _repository.Create(Arg.Any<SteadyStateTemperatureTest>(), cancellationToken).Returns(true);

            // Act
            var result = await _repository.Create(entity, cancellationToken);

            // Assert
            await _repository.Received(1).Create(Arg.Any<SteadyStateTemperatureTest>(), cancellationToken);
            result.Should().BeTrue();
        }
    }
}
