using FluentAssertions;
using LabAutomata.Wpf.Library.viewmodel;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace LabAutomata.Wpf.Tests.Unit.viewmodel {
    public class HeaderNavVmTests {
        private readonly HeaderNavVm _sut;
        private readonly ILogger _logger = Substitute.For<ILogger>();

        public HeaderNavVmTests () {
            _sut = new HeaderNavVm(_logger);
        }

        [Fact]
        public void PropertyChanged_ShouldFire_WhenSubCurrentVmPropertyChanged () {
            // arrange
            var monitor = _sut.Monitor();

            // act
            _sut.SubCurrentVm = new HomeVm(_logger);

            // assert
            monitor.Should().RaisePropertyChangeFor(vm => vm.SubCurrentVm);
        }

        [Fact]
        public void PropertyChanged_ShouldFire_WhenCurrentVmPropertyChanged () {
            // arrange
            var monitor = _sut.Monitor();

            // act
            _sut.CurrentVm = new HomeVm(_logger);

            // assert
            monitor.Should().RaisePropertyChangeFor(vm => vm.CurrentVm);
        }
    }
}