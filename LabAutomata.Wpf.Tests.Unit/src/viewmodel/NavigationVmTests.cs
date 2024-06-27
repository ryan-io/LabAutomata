using FluentAssertions;
using LabAutomata.Wpf.Library.common;
using LabAutomata.Wpf.Library.data_structures;
using LabAutomata.Wpf.Library.viewmodel;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace LabAutomata.Wpf.Tests.Unit.viewmodel {

	public class NavigationVmTests {
		private readonly NavigationVm _sut;
		private readonly IVmc _vmc = Substitute.For<IVmc>();
		private readonly IVmIdExtractor _extractor = Substitute.For<IVmIdExtractor>();
		private readonly ILogger _logger = Substitute.For<ILogger>();
		private readonly HomeVm _homeVm;
		private readonly HomeContentVm _homeContentVm;
		private readonly PlotViewModel _plotViewModel;

		public NavigationVmTests () {
			_homeVm = new HomeVm(_logger);
			_homeContentVm = new HomeContentVm(_plotViewModel, _logger);
			_sut = new NavigationVm(_vmc, _extractor, _logger);
			_vmc.Get(nameof(HomeVm)).Returns(_homeVm);
			_vmc.Get(nameof(HomeContentVm)).Returns(_homeContentVm);
			_vmc.Get(nameof(PlotViewModel)).Returns(_plotViewModel);
		}

		[Fact]
		public void Load_ShouldSetCurrentVmToHomeVm_WhenCalled () {
			// Arrange

			// Act
			_sut.Load();

			// Assert
			_sut.CurrentVm.Should().Be(_homeVm);
		}

		[Fact]
		public void ChangeVm_ShouldNotChangeCurrentVm_WhenCalledWithInvalidVmId () {
			// Arrange
			_vmc.Get("InvalidVm").Returns(x => null);
			_sut.Load();

			// Act
			_sut.ChangeVm.Execute("InvalidVm");

			// Assert
			_sut.CurrentVm.Should().BeNull();
		}
	}
}