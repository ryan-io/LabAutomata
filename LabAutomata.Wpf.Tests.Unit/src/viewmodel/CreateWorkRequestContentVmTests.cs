using FluentAssertions;
using LabAutomata.Db.models;
using LabAutomata.Wpf.Library.viewmodel;
using NSubstitute;

namespace LabAutomata.Wpf.Tests.Unit.viewmodel {
    public class CreateWorkRequestContentVmTests {
        private readonly CreateWorkRequestContentVm _sut = new(Substitute.For<IServiceProvider>());

        [Fact]
        public void PropertyChanged_ShouldFire_WhenNamePropertyChanged () {
            // arrange
            var monitor = _sut.Monitor();

            // act
            _sut.Name = "New Name";

            // assert
            monitor.Should().RaisePropertyChangeFor(vm => vm.Name);
        }

        [Fact]
        public void PropertyChanged_ShouldFire_WhenProgramPropertyChanged () {
            // arrange
            var monitor = _sut.Monitor();

            // act
            _sut.Program = "New Program";

            // assert
            monitor.Should().RaisePropertyChangeFor(vm => vm.Program);
        }

        [Fact]
        public void PropertyChanged_ShouldFire_WhenDescriptionPropertyChanged () {
            // arrange

            var monitor = _sut.Monitor();

            // act
            _sut.Description = "New Description";

            // assert
            monitor.Should().RaisePropertyChangeFor(vm => vm.Description);
        }

        [Fact]
        public void PropertyChanged_ShouldFire_WhenStartDatePropertyChanged () {
            // arrange
            var monitor = _sut.Monitor();

            // act
            _sut.StartDate = DateTime.Now;

            // assert
            monitor.Should().RaisePropertyChangeFor(vm => vm.StartDate);
        }

        [Fact]
        public void Tests_ShouldNotBeNull_OnNewInstanceCreation () {
            _sut.Tests.Should().NotBeNull();
            _sut.Tests.Should().BeEmpty();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(5)]
        [InlineData(10)]
        public void Tests_CountShouldBe_WhenTestsAreAdded (int count) {
            // arrange
            for (int i = 0; i < count; i++) {
                _sut.Tests.Add(new SteadyStateTemperatureTest());
            }

            // act

            // assert
            _sut.Tests.Count.Should().Be(count);
        }
    }
}
