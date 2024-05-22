using FluentAssertions;
using LabAutomata.Db.common;
using LabAutomata.Db.models;
using LabAutomata.Db.repository;
using Microsoft.EntityFrameworkCore;
using NSubstitute;

namespace LabAutomata.Db.Tests.Unit.repository {
    public class SsTemperatureRepositoryTests {
        private readonly ILabPostgreSqlDbContext _dbContext = Substitute.For<ILabPostgreSqlDbContext>();
        private readonly IRepository<SteadyStateTemperatureTest> _repository = Substitute.For<IRepository<SteadyStateTemperatureTest>>();

        [Fact]
        public async Task Create_ShouldAddEntityToDatabase () {
            // Arrange
            var entity = new SteadyStateTemperatureTest();
            var cancellationToken = CancellationToken.None;

            // Act
            var result = await _repository.Create(entity, cancellationToken);

            // Assert
            await _dbContext.SsTempTests.Received(1).AddAsync(entity, cancellationToken);
            await _dbContext.Received(1).PostgreSqlDb.SaveChangesAsync(cancellationToken);
            result.Should().BeTrue();
        }

        [Fact]
        public async Task Get_ShouldRetrieveEntityFromDatabase () {
            // Arrange
            var id = 1;
            var cancellationToken = CancellationToken.None;
            var entity = new SteadyStateTemperatureTest { Id = id };
            _dbContext.SsTempTests.FirstOrDefaultAsync(t => t.Id == id, cancellationToken: cancellationToken)
                .Returns(entity);

            // Act
            var result = await _repository.Get(id, cancellationToken);

            // Assert
            await _dbContext.SsTempTests.Received(1)
                .FirstOrDefaultAsync(t => t.Id == id, cancellationToken: cancellationToken);
            result.Should().Be(entity);
        }

        [Fact]
        public async Task Upsert_ShouldUpdateExistingEntity () {
            // Arrange
            var id = 1;
            var entity = new SteadyStateTemperatureTest { Id = id };
            var cancellationToken = CancellationToken.None;
            _dbContext.SsTempTests.FirstOrDefaultAsync(e => id == e.Id, cancellationToken: cancellationToken)
                .Returns(entity);

            // Act
            var result = await _repository.Upsert(id, entity, cancellationToken);

            // Assert
            await _dbContext.SsTempTests.Received(1)
                .FirstOrDefaultAsync(e => id == e.Id, cancellationToken: cancellationToken);
            await _dbContext.Received(1).PostgreSqlDb.SaveChangesAsync(cancellationToken);
            _dbContext.PostgreSqlDb.Entry(entity).Received(1).CurrentValues.SetValues(entity);
            result.Should().BeTrue();
        }

        [Fact]
        public async Task Upsert_ShouldCreateNewEntity () {
            // Arrange
            var id = 1;
            var entity = new SteadyStateTemperatureTest { Id = id };
            var cancellationToken = CancellationToken.None;
            _dbContext.SsTempTests.FirstOrDefaultAsync(e => id == e.Id, cancellationToken: cancellationToken)
                .Returns((SteadyStateTemperatureTest)null!);

            // Act
            var result = await _repository.Upsert(id, entity, cancellationToken);

            // Assert
            await _dbContext.SsTempTests.Received(1)
                .FirstOrDefaultAsync(e => id == e.Id, cancellationToken: cancellationToken);
            await _dbContext.Received(1).PostgreSqlDb.SaveChangesAsync(cancellationToken);
            await _repository.Received(1).Create(entity, cancellationToken);
            result.Should().BeTrue();
        }

        [Fact]
        public async Task Delete_ShouldRemoveEntityFromDatabase () {
            // Arrange
            var instanceId = 1;
            var cancellationToken = CancellationToken.None;
            var entity = new SteadyStateTemperatureTest { InstanceId = instanceId };
            _dbContext.SsTempTests
                .FirstOrDefaultAsync(e => instanceId == e.InstanceId, cancellationToken: cancellationToken)
                .Returns(entity);

            // Act
            var result = await _repository.Delete(instanceId, cancellationToken);

            // Assert
            await _dbContext.SsTempTests.Received(1)
                .FirstOrDefaultAsync(e => instanceId == e.InstanceId, cancellationToken: cancellationToken);
            await _dbContext.Received(1).PostgreSqlDb.SaveChangesAsync(cancellationToken);
            _dbContext.Received(1).PostgreSqlDb.Attach(entity);
            _dbContext.SsTempTests.Received(1).Remove(entity);
            result.Should().BeTrue();
        }
    }
}
