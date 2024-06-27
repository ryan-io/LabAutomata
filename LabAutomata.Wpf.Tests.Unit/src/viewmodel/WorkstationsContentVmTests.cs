using LabAutomata.Db.models;
using LabAutomata.Db.repository;
using LabAutomata.Wpf.Library.viewmodel;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace LabAutomata.Wpf.Tests.Unit.viewmodel {

	public class WorkstationsContentVmTests {
		private readonly WorkstationsContentVm _sut;
		private readonly ILogger _logger = Substitute.For<ILogger>();
		private readonly IRepository<Workstation> _repository = Substitute.For<IRepository<Workstation>>();

		public WorkstationsContentVmTests () {
			_sut = new WorkstationsContentVm(_repository, _logger);
		}

		/*
        [Fact]
        public async Task Constructor_ShouldInitializeWorkstations_WhenCalled () {
            // Arrange
            var workstations = new List<Workstation> { new(), new() };
            _repository.GetAll(CancellationToken.None).Returns(Task.FromResult(workstations));

            // Act
            _sut.

             // Assert
             navigator.Workstations.Should().NotBeNull();
            navigator.Workstations.Count.Should().Be(workstations.Count);
        }*/
	}
}