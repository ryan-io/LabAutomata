using FluentAssertions;
using LabAutomata.DataAccess.service;
using LabAutomata.Db.models;
using LabAutomata.Wpf.Library.domain_models;
using LabAutomata.Wpf.Library.mediator_stores;
using NSubstitute;

namespace LabAutomata.Wpf.Tests.Unit.mediator_stores {
	public class WorkstationStoreTests {
		private readonly IWorkstationService _service = Substitute.For<IWorkstationService>();
		private readonly WorkstationStore _sut;

		public WorkstationStoreTests () {
			_sut = new WorkstationStore(_service);
		}

		[Fact]
		public void AddWorkstation_ShouldInvokeStateChangedEvent_WhenWorkstationAdded () {
			// Arrange
			var model = new WorkstationDomainModel(new Workstation());
			using var monitor = _sut.Monitor();

			// Act
			_sut.AddWorkstation(model);


			// Assert
			monitor.Should().Raise("StateChanged");
		}

		[Fact]
		public async Task Load_ShouldLoadWorkstations_WhenLoadInvoked () {
			// Arrange
			var cancellationToken = new CancellationToken();
			var workstations = new List<WorkstationResponse>();

			_service.GetAll(cancellationToken).Returns(workstations);

			// Act
			await _sut.Load(cancellationToken);

			// Assert
			await _service.Received(1).GetAll(cancellationToken);
			_sut.Workstations.Should().HaveCount(2);
		}
	}
}
