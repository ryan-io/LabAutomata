using FluentAssertions;
using LabAutomata.Db.models;
using LabAutomata.Db.repository;
using LabAutomata.Wpf.Library.adapter;
using LabAutomata.Wpf.Library.data_structures;
using LabAutomata.Wpf.Library.viewmodel;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Windows.Threading;
using SteadyStateTemperatureTest = LabAutomata.Db.models.SteadyStateTemperatureTest;

namespace LabAutomata.Wpf.Tests.Unit.viewmodel {
    public class CreateWorkRequestContentVmTests {
        private readonly CreateWorkRequestContentVm _sut;
        private readonly ILogger _logger = Substitute.For<ILogger>();
        private readonly IRepository<WorkRequest> _repository = Substitute.For<IRepository<WorkRequest>>();
        private readonly IAdapter<Dispatcher> _adapter = Substitute.For<IAdapter<Dispatcher>>();
        private readonly IVmc _vmc = Substitute.For<IVmc>();
        private readonly IRepository<Manufacturer> _manufacturerRepository = Substitute.For<IRepository<Manufacturer>>();

        public CreateWorkRequestContentVmTests () {
            _sut = new CreateWorkRequestContentVm(_repository, _manufacturerRepository, _adapter, _logger);
        }

        [Fact]
        public void PropertyChanged_ShouldFire_WhenNamePropertyChanged () {
            // arrange
            var monitor = _sut.Model.Monitor();

            // act
            _sut.Model.Name = "New Name";

            // assert
            monitor.Should().RaisePropertyChangeFor(vm => vm.Name);
        }

        [Fact]
        public void PropertyChanged_ShouldFire_WhenProgramPropertyChanged () {
            // arrange
            var monitor = _sut.Model.Monitor();

            // act
            _sut.Model.Program = "New Program";

            // assert
            monitor.Should().RaisePropertyChangeFor(vm => vm.Program);
        }

        [Fact]
        public void PropertyChanged_ShouldFire_WhenDescriptionPropertyChanged () {
            // arrange

            var monitor = _sut.Model.Monitor();

            // act
            _sut.Model.Description = "New Description";

            // assert
            monitor.Should().RaisePropertyChangeFor(vm => vm.Description);
        }

        [Fact]
        public void PropertyChanged_ShouldFire_WhenStartDatePropertyChanged () {
            // arrange
            var monitor = _sut.Model.Monitor();

            // act
            _sut.Model.StartDate = DateTime.Now;

            // assert
            monitor.Should().RaisePropertyChangeFor(vm => vm.StartDate);
        }

        [Fact]
        public void Tests_ShouldNotBeNull_OnNewInstanceCreation () {
            _sut.Model.Tests.Should().NotBeNull();
            _sut.Model.Tests.Should().BeEmpty();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(5)]
        [InlineData(10)]
        public void Tests_CountShouldBe_WhenTestsAreAdded (int count) {
            // arrange
            for (int i = 0; i < count; i++) {
                _sut.Model.Tests!.Add(new SteadyStateTemperatureTest());
            }

            // act

            // assert
            _sut.Model.Tests!.Count.Should().Be(count);
        }
    }
}
