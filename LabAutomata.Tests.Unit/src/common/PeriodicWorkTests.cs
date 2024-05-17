using FluentAssertions;
using LabAutomata.Library.common;
using NSubstitute;
using System.Reflection;

namespace LabAutomata.Tests.Unit.common;

public class PeriodicWorkTests : IDisposable {
    // modify Period to adjust tick rate
    private const int Period = 1;

    // system under test
    private readonly PeriodicWork _sut = new(Period);

    public PeriodicWorkTests () {

    }

    [Fact]
    public async Task WorkAsync_ShouldInvokeCallback_UntilExitConditionIsTrue () {
        var callback = Substitute.For<Action>();
        var exitCondition = Substitute.For<Func<bool>>();
        exitCondition.Invoke().Returns(false, false, true); // exit after 2 invocations

        await _sut.WorkAsync(callback, exitCondition);

        callback.Received(2).Invoke();
        exitCondition.Received(3).Invoke();
    }

    [Fact]
    public async Task WorkAsync_ShouldInvokeCompleteCallback_WhenExitConditionIsTrue () {
        var completeCallback = Substitute.For<Action>();
        var exitCondition = Substitute.For<Func<bool>>();
        exitCondition.Invoke().Returns(true); // exit immediately

        await _sut.WorkAsync(null, exitCondition, completeCallback);

        completeCallback.Received(1).Invoke();
    }

    [Fact]
    public void Dispose_ShouldDisposeTimer_WhenDisposeIsInvoked () {
        _sut.Dispose();

        // assert that _isDisposed is true
        // this requires reflection as _isDisposed is private
        var isDisposed = (bool)typeof(PeriodicWork).
            GetField("_isDisposed", BindingFlags.NonPublic | BindingFlags.Instance)
            ?.GetValue(_sut)!;

        isDisposed.Should().BeTrue();
    }

    [Fact]
    public async Task WorkAsync_ShouldTickTwiceThenComplete_WhenValidCallbacksProvided () {
        // arrange
        // simulates 'ticking' twice
        _sut.SetPeriod(2);  // changes the period to 3 seconds; work has not begun yet

        // capturing a modifiable integer on the heap
        CaptureInt ci = new CaptureInt();

        Action cb = () => ci.Get()++;

        Func<bool> ecb = Substitute.For<Func<bool>>();
        ecb.Invoke().Returns(_ => ci.Get() >= 2);

        // act
        await _sut.WorkAsync(cb, ecb);

        // assert
        // received 3 calls, false -> false -> true
        ecb.Received(3).Invoke();

        // assumption is Get() should be 2 if cb is invoked twice
        ci.Get().Should().Be(2);
    }

    public void Dispose () {
        _sut.Dispose();
    }

    class CaptureInt {
        public ref int Get () => ref i;

        int i = 0;
    }
}