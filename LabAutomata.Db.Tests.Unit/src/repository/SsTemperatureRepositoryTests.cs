//using FluentAssertions;
//using LabAutomata.Db.common;
//using LabAutomata.Db.models;
//using LabAutomata.Db.repository;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using NSubstitute;

//namespace LabAutomata.Db.Tests.Unit.src.repository;

//public class SsTemperatureRepositoryTests {
//    private readonly LabPostgreSqlDbContext _dbContext;
//    private readonly SsTemperatureRepository _repository;

//    public SsTemperatureRepositoryTests () {
//        var options = new DbContextOptionsBuilder<LabPostgreSqlDbContext>()
//            .UseInMemoryDatabase(databaseName: "TestDatabase")
//            .Options;

//        var config = Substitute.For<IConfiguration>();

//        _dbContext = new LabPostgreSqlDbContext(config);
//        _repository = new SsTemperatureRepository(_dbContext);
//    }

//    [Fact]
//    public async Task Create_AddsEntityToDatabase () {
//        var entity = SteadyStateTemperatureTest.New(34342);

//        await _repository.Create(entity);

//        _dbContext.SsTempTests.Should().Contain(entity);
//    }

//    [Fact]
//    public void Get_RetrievesEntityFromDatabase () {
//        var entity = SteadyStateTemperatureTest.New(1);
//        _dbContext.SsTempTests.Add(entity);
//        _dbContext.SaveChanges();

//        var retrievedEntity = _repository.Get(1);

//        retrievedEntity.Should().Be(entity);
//    }

//    [Fact]
//    public async Task Update_UpdatesEntityInDatabase () {
//        var entity = SteadyStateTemperatureTest.New(1);
//        _dbContext.SsTempTests.Add(entity);
//        await _dbContext.SaveChangesAsync();

//        var value = 25;
//        entity.Data.Add(new TemperaturePoint { InstanceId = entity.InstanceId, Value = value });
//        await _repository.Update(entity);

//        var check =
//            _dbContext.SsTempTests.Include(steadyStateTemperatureTest
//                => steadyStateTemperatureTest.Data)
//                .Single()
//                .Data
//                    .Where(x => Math.Abs(x.Value - value) < 0.005f);

//        check.Should().NotBeNull();
//    }

//    [Fact]
//    public async Task Delete_RemovesEntityFromDatabase () {
//        var entity = SteadyStateTemperatureTest.New(1);
//        _dbContext.SsTempTests.Add(entity);
//        await _dbContext.SaveChangesAsync();

//        await _repository.Delete(entity);

//        _dbContext.SsTempTests.Should().NotContain(entity);
//    }
//}