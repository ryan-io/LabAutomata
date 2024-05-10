using FluentAssertions;
using LabAutomata.Wpf.Library.common;
using NSubstitute;

namespace LabAutomata.Wpf.Tests.Unit.common;

public class DelegateCommandTests {
    [Fact]
    public void CanExecute_ShouldReturnTrue_WhenCanExecuteFuncIsNull () {
        var command = new DelegateCommand(null, null);

        command.CanExecute(null).Should().BeTrue();
    }

    [Fact]
    public void CanExecute_ShouldReturnTrue_WhenCanExecuteFuncIsNotNull () {
        var canExecuteFunc = Substitute.For<Func<object, bool>>();
        canExecuteFunc.Invoke(Arg.Any<object>()).Returns(true);

        var command = new DelegateCommand(null, canExecuteFunc);

        command.CanExecute(null).Should().BeTrue();

        canExecuteFunc.Received(1).Invoke(Arg.Any<object>());
    }

    [Fact]
    public void Execute_ShouldInvokeActionContext_WhenContextProvided () {
        var wasExecuted = false;
        var command = new DelegateCommand(_ => wasExecuted = true);

        command.Execute(null);

        wasExecuted.Should().BeTrue();
    }

    [Fact]
    public void Execute_ShouldInvokeOnExecutedCallback_WhenAndExecutedCallbackProvided () {
        var wasCallbackInvoked = false;
        var command = new DelegateCommand(null, null);
        command.OnExecutedCallback += () => wasCallbackInvoked = true;

        command.Execute(null);

        wasCallbackInvoked.Should().BeTrue();
    }

    [Fact]
    public void CanExecuteChanged_ShouldNotBeNotInvoked_WhenNotSubscribed () {
        var command = new DelegateCommand(null, null);

        Action act = () => command.RaiseCanExecuteChanged();

        act.Should().NotThrow();
    }

}