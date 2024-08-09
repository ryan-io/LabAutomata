using FluentAssertions;
using LabAutomata.Wpf.Library.data_structures;
using LabAutomata.Wpf.Library.viewmodel;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace LabAutomata.Wpf.Tests.Unit.viewmodel {

	public class HeaderNavVmTests {
		private readonly HeaderNavVm _sut;
		private readonly ILogger _logger = Substitute.For<ILogger>();
		private readonly IVmc _vmc = Substitute.For<IVmc>();

		public HeaderNavVmTests () {
			_sut = new HeaderNavVm(_vmc, _logger);
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

		[Fact]
		public void Load_ShouldSetCurrentVmToHomeVm_WhenCalled () {
			// arrange
			_vmc.Get(nameof(HomeVm)).Returns(new HomeVm(_logger));

			// act
			_sut.Load();

			// assert
			_sut.CurrentVm.Should().BeOfType<HomeVm>();
		}

		[Fact]
		public void ChangeVm_ShouldChangeCurrentVm_WhenCalledWithValidVmId () {
			// arrange
			const string tvm = "TestVm";
			_vmc.Get(tvm).Returns(new HomeVm());
			_sut.Load();

			// act
			_sut.ChangeVm!.Execute(tvm);

			// assert
			_sut.CurrentVm.Should().BeOfType<HomeVm>();
		}

		[Fact]
		public void ChangeVm_ShouldNotChangeCurrentVm_WhenCalledWithInvalidVmId () {
			// arrange
			const string tvm = "TestVm";
			_vmc.Get(tvm).Returns(x => throw new Exception());
			_sut.Load();

			// act
			_sut.CurrentVm = new HomeVm(_logger);
			_sut.ChangeVm!.Execute("InvalidVm");

			// assert
			_sut.CurrentVm.Should().BeNull();
		}
	}
}