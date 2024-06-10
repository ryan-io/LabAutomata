using FluentAssertions;
using LabAutomata.Wpf.Library.common;
using NSubstitute;

namespace LabAutomata.Wpf.Tests.Unit.common;

public class CommandTests {

	[Fact]
	public void CanExecute_ShouldReturnTrue_WhenCanExecuteFuncIsNull () {
		var command = new Command(null, null);

		command.CanExecute(null).Should().BeTrue();
	}

	[Fact]
	public void CanExecute_ShouldReturnTrue_WhenCanExecuteFuncIsNotNull () {
		var canExecuteFunc = Substitute.For<Func<object?, bool>>();
		canExecuteFunc.Invoke(Arg.Any<object>()).Returns(true);

		var command = new Command(null, canExecuteFunc);

		command.CanExecute(null).Should().BeTrue();

		canExecuteFunc.Received(1).Invoke(Arg.Any<object>());
	}

	[Fact]
	public void Execute_ShouldInvokeActionContext_WhenContextProvided () {
		var wasExecuted = false;
		var command = new Command(_ => wasExecuted = true);

		command.Execute(null);

		wasExecuted.Should().BeTrue();
	}

	[Fact]
	public void Execute_ShouldNotInvokeOnExecutedCallback_WhenNoContextProvided () {
		var wasCallbackInvoked = false;
		var command = new Command(null);
		command.OnExecutedCallback += () => wasCallbackInvoked = true;

		command.Execute(null);

		wasCallbackInvoked.Should().BeFalse();
	}

	[Fact]
	public void CanExecuteChanged_ShouldNotBeNotInvoked_WhenNotSubscribed () {
		var command = new Command(null, null);

		Action act = () => command.RaiseCanExecuteChanged();

		act.Should().NotThrow();
	}

	[Fact]
	public void CanExecute_ShouldReturnFalse_WhenCanExecuteFuncReturnsFalse () {
		var canExecuteFunc = Substitute.For<Func<object?, bool>>();
		canExecuteFunc.Invoke(Arg.Any<object>()).Returns(false);

		var command = new Command(null, canExecuteFunc);

		command.CanExecute(null).Should().BeFalse();

		canExecuteFunc.Received(1).Invoke(Arg.Any<object>());
	}

	[Fact]
	public void Execute_ShouldNotInvokeOnExecutedCallback_WhenCanExecuteReturnsFalse () {
		var wasCallbackInvoked = false;
		var command = new Command(null, _ => false);
		command.OnExecutedCallback += () => wasCallbackInvoked = true;

		command.Execute(null);

		wasCallbackInvoked.Should().BeFalse();
	}
}