using FluentAssertions;
using LabAutomata.Wpf.Library.adapter;
using LabAutomata.Wpf.Library.data_structures;
using LabAutomata.Wpf.Library.viewmodel;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System.Windows.Threading;

namespace LabAutomata.Wpf.Tests.Unit.viewmodel {
	public class MainWindowVmTests {
		private readonly MainWindowVm _sut;
		private readonly IVmc _vmc = Substitute.For<IVmc>();
		private readonly ILogger _logger = Substitute.For<ILogger>();
		private readonly IAdapter<Dispatcher> _adapter = Substitute.For<IAdapter<Dispatcher>>();
		private readonly HomeVm _homeVm;
		private readonly HomeContentVm _homeContentVm;
		private readonly NavigationVm _navigationVm;
		private readonly HeaderNavVm _headerNavVm;

		public MainWindowVmTests () {
			_homeVm = new HomeVm(_logger);
			_homeContentVm = new HomeContentVm(_logger);
			_navigationVm = new NavigationVm(_vmc, _logger);
			_headerNavVm = new HeaderNavVm(_vmc, _logger);
			_sut = new MainWindowVm(_vmc, _navigationVm, _homeVm, _homeContentVm, _logger);
			_vmc.Get(nameof(HomeVm)).Returns(_homeVm);
			_vmc.Get(nameof(HomeContentVm)).Returns(_homeContentVm);
			_vmc.Get(nameof(NavigationVm)).Returns(_navigationVm);
			_vmc.Get(nameof(HeaderNavVm)).Returns(_headerNavVm);
		}

		[Fact]
		public void Load_ShouldSetFocusedVm_WhenCalled () {
			// Arrange

			// Act
			_sut.Load();

			// Assert
			_sut.FocusedVm.Should().Be(_homeVm);
			_sut.SubFocusedVm.Should().Be(_homeContentVm);
			_sut.NavVm.Should().Be(_navigationVm);
			_sut.MainNavVm.Should().Be(_headerNavVm);
		}

		[Fact]
		public void Load_ShouldThrowException_WhenMainNavVmIsNull () {
			// Arrange
			_vmc.Get(nameof(HeaderNavVm)).ReturnsNullForAnyArgs();

			// Act
			Action act = () => _sut.Load();

			// Assert
			act.Should().Throw<NullReferenceException>().WithMessage("Main window viemwodel cannot be null.");
		}
	}
}
