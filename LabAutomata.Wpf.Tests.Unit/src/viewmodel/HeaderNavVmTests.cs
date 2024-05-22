using FluentAssertions;
using LabAutomata.Wpf.Library.viewmodel;
using NSubstitute;

namespace LabAutomata.Wpf.Tests.Unit.viewmodel {
    public class HeaderNavVmTests {
        private readonly HeaderNavVm _sut = new(Substitute.For<IServiceProvider>());

        [Fact]
        public void PropertyChanged_ShouldFire_WhenSubCurrentVmPropertyChanged () {
            // arrange
            var monitor = _sut.Monitor();

            // act
            _sut.SubCurrentVm = new HomeVm(Substitute.For<IServiceProvider>());

            // assert
            monitor.Should().RaisePropertyChangeFor(vm => vm.SubCurrentVm);
        }

        [Fact]
        public void PropertyChanged_ShouldFire_WhenCurrentVmPropertyChanged () {
            // arrange
            var monitor = _sut.Monitor();

            // act
            _sut.CurrentVm = new HomeVm(Substitute.For<IServiceProvider>());

            // assert
            monitor.Should().RaisePropertyChangeFor(vm => vm.CurrentVm);
        }
    }
}