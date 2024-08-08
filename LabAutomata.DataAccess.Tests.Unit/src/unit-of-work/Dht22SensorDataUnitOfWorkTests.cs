//using FluentAssertions;
//using LabAutomata.DataAccess.request;
//using LabAutomata.DataAccess.unit_of_work;
//using LabAutomata.Db.common;
//using LabAutomata.Db.models;
//using Microsoft.EntityFrameworkCore;
//using NSubstitute;

////TODO: move this to integration testing project
//namespace LabAutomata.DataAccess.Tests.Unit.src.unit_of_work {
//	public class Dht22SensorDataUnitOfWorkTests {
//		private readonly IDbContextFactory<PostgreSqlDbContext> _factory = Substitute.For<IDbContextFactory<PostgreSqlDbContext>>();
//		private readonly IPostgreSqlDbContext _dbContext = Substitute.For<IPostgreSqlDbContext>();
//		private readonly IDht22SensorDataUnitOfWork _sut;

//		public Dht22SensorDataUnitOfWorkTests () {
//			_sut = new Dht22SensorDataUnitOfWork(_factory);
//		}

//		[Fact]
//		public async Task RunWork_ShouldAddDataToSensor_WhenSensorExists () {
//			// Arrange
//			var location = new Location() {
//				City = "test city",
//				Id = 1,
//				State = "test state",
//				Address = "test address",
//				Country = "test country",
//				Name = "test location"
//			};

//			var sensor = new Dht22Sensor {
//				Name = "test sensor",
//				Location = location,
//				Id = 1,
//				Data = new List<Dht22Data>()
//			};

//			var request = new Dht22AddDataToSensorRequest(1, "test data");

//			// Act
//			//_sut.RunWork(
//			//	request,
//			//	Arg.Any<CancellationToken>()).Returns(sensor);
//			var result = await _sut.RunWork(request, CancellationToken.None);

//			// Assert
//			result.Should().NotBeNull();
//			result.Data.Should().ContainSingle(d => d.JsonString == "test data");
//		}
//	}
//}
