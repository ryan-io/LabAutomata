using FluentAssertions;
using LabAutomata.DataAccess.response;
using LabAutomata.DataAccess.service;
using LabAutomata.Wpf.Library.domain_models;
using LabAutomata.Wpf.Library.mediator_stores;
using Microsoft.EntityFrameworkCore;
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
			var model = new WorkstationDomain(GetResponse());
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

			_service.GetWorkstations(cancellationToken).Returns(workstations);

			// Act
			await _sut.Load(cancellationToken);

			// Assert
			await _service.Received(1).GetWorkstations(cancellationToken);
			_sut.Workstations.Should().HaveCount(2);
		}

		static WorkstationResponse GetResponse () {
			var location = new LocationResponse(
				0,
				"Name",
				"country",
				"city",
				"state",
				"address",
				EntityState.Unchanged);

			return new WorkstationResponse(
				0,
				"Name",
				100,
				"Description",
				DateTime.UtcNow,
				location,
				EntityState.Unchanged);
		}
	}
}
