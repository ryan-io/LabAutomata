using FluentAssertions;
using LabAutomata.Db.models;
using LabAutomata.Db.repository;
using LabAutomata.Wpf.Library.models;
using LabAutomata.Wpf.Library.viewmodel;
using NSubstitute;
using System.Collections.ObjectModel;

namespace LabAutomata.Wpf.Tests.Unit.viewmodel {
    public class WorkRequestContentVmTests {
        private readonly IWorkRequestContentVm _sut;
        private readonly IRepository<WorkRequest> _repository = Substitute.For<IRepository<WorkRequest>>();

        public WorkRequestContentVmTests () {
            var serviceProvider = Substitute.For<IServiceProvider>();
            _sut = Substitute.For<IWorkRequestContentVm>();
        }

        [Fact]
        public void LoadAsync_ShouldPopulateWorkRequests () {
            // arrange
            var workRequests = new List<WorkRequest>
            {
                new WorkRequest { Name = "WorkRequest1", Program = "Program1", Description = "Description1", Started = DateTime.Now, Tests = new List<Test>() },
                new WorkRequest { Name = "WorkRequest2", Program = "Program2", Description = "Description2", Started = DateTime.Now, Tests = new List<Test>() },
                new WorkRequest { Name = "WorkRequest3", Program = "Program3", Description = "Description3", Started = DateTime.Now, Tests = new List<Test>() }
            };
            _repository.GetAll(Arg.Any<CancellationToken>()).Returns(workRequests);

            List<WorkRequestDomainModel> models = new();

            foreach (var wr in workRequests) {
                var wrdm = new WorkRequestDomainModel(wr.Name, wr.Program, wr.Description, wr.Started, wr.WrId);
                models.Add(wrdm);
            }

            var oc = new ObservableCollection<WorkRequestDomainModel>(models);
            _sut.WorkRequests.Returns(oc);

            // assert
            _sut.WorkRequests.Should().HaveCount(workRequests.Count);
            for (int i = 0; i < workRequests.Count; i++) {
                var expected = new WorkRequestDomainModel(workRequests[i].Name, workRequests[i].Program, workRequests[i].Description, workRequests[i].Started, workRequests[i].WrId);
                _sut.WorkRequests[i].Should().BeEquivalentTo(expected);
            }
        }
    }
}
