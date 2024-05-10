//using FluentAssertions;
//using LabAutomata.Wpf.Library.viewmodel;
//using System.ComponentModel;

//namespace LabAutomata.Wpf.Tests.Unit.viewmodel;

//public class BaseTests {
//    [Fact]
//    public void HasErrors_ReturnsFalse_WhenShouldNotifyErrorsIsFalse () {
//        var baseObj = new Base(false);
//        baseObj.HasErrors.Should().BeFalse();
//    }

//    [Fact]
//    public void HasErrors_ReturnsFalse_WhenErrorsCollectionIsEmpty () {
//        var baseObj = new Base(true);
//        baseObj.HasErrors.Should().BeFalse();
//    }

//    [Fact]
//    public void RaisePropertyChanged_InvokesPropertyChanged () {
//        var wasEventRaised = false;
//        var baseObj = new Base();
//        baseObj.PropertyChanged += (sender, args) => wasEventRaised = true;

//        baseObj.RaisePropertyChanged();

//        wasEventRaised.Should().BeTrue();
//    }

//    [Fact]
//    public void GetErrors_ReturnsEmpty_WhenShouldNotifyErrorsIsFalse () {
//        var baseObj = new Base(false);
//        var errors = baseObj.GetErrors();
//        errors.Should().Be(null);
//    }

//    [Fact]
//    public void GetErrors_ReturnsEmpty_WhenPropertyNameIsNullOrWhiteSpace () {
//        var baseObj = new Base(true);
//        var errors = baseObj.GetErrors(null);
//        errors.Should().BeEmpty();
//    }

//    [Fact]
//    public void OnErrorsChanged_DoesNotInvokeErrorsChanged_WhenShouldNotifyErrorsIsFalse () {
//        var wasEventRaised = false;
//        var baseObj = new Base(false);
//        baseObj.ErrorsChanged += (sender, args) => wasEventRaised = true;

//        baseObj.OnErrorsChanged(new DataErrorsChangedEventArgs("Test"));

//        wasEventRaised.Should().BeFalse();
//    }

//    [Fact]
//    public void AddError_AddsErrorToErrorsCollection () {
//        var baseObj = new Base(true);
//        baseObj.AddError("Test error", "Test");

//        baseObj.HasErrors.Should().BeTrue();
//    }

//    [Fact]
//    public void RemoveErrorsForProperty_RemovesErrorsForProperty () {
//        var baseObj = new Base(true);
//        baseObj.AddError("Test error", "Test");
//        baseObj.RemoveErrorsForProperty("Test");

//        baseObj.HasErrors.Should().BeFalse();
//    }

//    [Fact]
//    public void ClearErrorsForProperty_ClearsErrorsForProperty () {
//        var baseObj = new Base(true);
//        baseObj.AddError("Test error", "Test");
//        baseObj.ClearErrorsForProperty("Test");

//        baseObj.HasErrors.Should().BeFalse();
//    }

//    [Fact]
//    public void TryGetErrorString_ReturnsFalse_WhenPropertyNameIsNullOrWhiteSpace () {
//        var baseObj = new Base(true);
//        var result = baseObj.TryGetErrorString(null, out var error);

//        result.Should().BeFalse();
//    }
//}