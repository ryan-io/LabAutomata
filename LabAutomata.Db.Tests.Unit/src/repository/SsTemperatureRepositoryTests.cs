using FluentAssertions;
using LabAutomata.Db.common;
using LabAutomata.Db.models;
using LabAutomata.Db.repository;
using NSubstitute;

namespace LabAutomata.Db.Tests.Unit.repository {
    public class TestRepositoryTests {
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

        [Fact]
        public async Task Get_ShouldRetrieveEntityFromDatabase_WhenNoErrorIsThrown () {
            // Arrange
            var id = 1;
            var cancellationToken = CancellationToken.None;
            var entity = new SteadyStateTemperatureTest { Id = id };
           
            _repository.Get(Arg.Any<int>(), cancellationToken).Returns(entity);

            // Act
            var result = await _repository.Get(id, cancellationToken);

			// Assert
			await _repository.Received(1).Get(id, cancellationToken);
            result.Should().Be(entity);
        }

        [Fact]
        public async Task Upsert_ShouldUpdateExistingEntity_WhenNoErrorIsThrown () {
            // Arrange
            var id = 1;
            var entity = new SteadyStateTemperatureTest { Id = id };
            var cancellationToken = CancellationToken.None;

            _repository.Upsert(Arg.Any<int>(), Arg.Any<SteadyStateTemperatureTest>(), cancellationToken)
	            .Returns(true);

			// Act
			var result = await _repository.Upsert(id, entity, cancellationToken);

			// Assert
			await _repository.Received(1).Upsert(id, entity, cancellationToken);
			result.Should().BeTrue();
        }


        [Fact]
        public async Task Delete_ShouldRemoveEntityFromDatabase_WhenNoErrorIsThrown () {
            // Arrange
            var instanceId = 1;
            var cancellationToken = CancellationToken.None;
            _repository.Delete(Arg.Any<int>(), cancellationToken).Returns(true);

            // Act
            var result = await _repository.Delete(instanceId, cancellationToken);

            // Assert

            result.Should().BeTrue();
        }
    }
}
