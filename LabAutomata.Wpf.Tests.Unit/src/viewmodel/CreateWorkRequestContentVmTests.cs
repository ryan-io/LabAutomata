using FluentAssertions;
using LabAutomata.Db.models;
using LabAutomata.Wpf.Library.viewmodel;

namespace LabAutomata.Wpf.Tests.Unit.viewmodel {
    public class CreateWorkRequestContentVmTests {
        private readonly CreateWorkRequestContentVm _sut; //= new(Substitute.For<IServiceProvider>());

        public CreateWorkRequestContentVmTests () {
            _sut.Model.Tests = new List<Test>();
        }

        [Fact]
        public void PropertyChanged_ShouldFire_WhenNamePropertyChanged () {
            // arrange
            var monitor = _sut.Monitor();

            // act
            _sut.Model.Name = "New Name";

            // assert
            monitor.Should().RaisePropertyChangeFor(vm => vm.Model.Name);
        }

        [Fact]
        public void PropertyChanged_ShouldFire_WhenProgramPropertyChanged () {
            // arrange
            var monitor = _sut.Monitor();

            // act
            _sut.Model.Program = "New Program";

            // assert
            monitor.Should().RaisePropertyChangeFor(vm => vm.Model.Program);
        }

        [Fact]
        public void PropertyChanged_ShouldFire_WhenDescriptionPropertyChanged () {
            // arrange

            var monitor = _sut.Monitor();

            // act
            _sut.Model.Description = "New Description";

            // assert
            monitor.Should().RaisePropertyChangeFor(vm => vm.Model.Description);
        }

        [Fact]
        public void PropertyChanged_ShouldFire_WhenStartDatePropertyChanged () {
            // arrange
            var monitor = _sut.Monitor();

            // act
            _sut.Model.StartDate = DateTime.Now;

            // assert
            monitor.Should().RaisePropertyChangeFor(vm => vm.Model.StartDate);
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
