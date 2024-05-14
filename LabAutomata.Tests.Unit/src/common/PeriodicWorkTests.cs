using FluentAssertions;
using LabAutomata.Library.common;
using NSubstitute;
using System.Reflection;

namespace LabAutomata.Tests.Unit.common;

public class PeriodicWorkTests {
    [Fact]
    public async Task WorkAsync_ShouldInvokeCallback_UntilExitConditionIsTrue () {
        var callback = Substitute.For<Action>();
        var exitCondition = Substitute.For<Func<bool>>();
        exitCondition.Invoke().Returns(false, false, true); // exit after 2 invocations

        using (var work = new PeriodicWork()) {
            await work.WorkAsync(callback, exitCondition);
        }

        callback.Received(2).Invoke();
        exitCondition.Received(3).Invoke();
    }

    [Fact]
    public async Task WorkAsync_ShouldInvokeCompleteCallback_WhenExitConditionIsTrue () {
        var completeCallback = Substitute.For<Action>();
        var exitCondition = Substitute.For<Func<bool>>();
        exitCondition.Invoke().Returns(true); // exit immediately

        using (var work = new PeriodicWork()) {
            await work.WorkAsync(null, exitCondition, completeCallback);
        }

        completeCallback.Received(1).Invoke();
    }

    [Fact]
    public void Dispose_ShouldDisposeTimer_WhenDisposeIsInvoked () {
        var work = new PeriodicWork();
        work.Dispose();

        // assert that _isDisposed is true
        // this requires reflection as _isDisposed is private
        var isDisposed = (bool)typeof(PeriodicWork).
            GetField("_isDisposed", BindingFlags.NonPublic | BindingFlags.Instance)
            ?.GetValue(work)!;

        isDisposed.Should().BeTrue();
    }
}