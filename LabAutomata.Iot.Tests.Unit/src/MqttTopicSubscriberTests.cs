using FluentAssertions;
using LabAutomata.IoT;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace LabAutomata.Iot.Tests.Unit.src {

	public class MqttTopicSubscriberTests {
		private readonly ILogger<MqttTopicSubscriber> _logger = Substitute.For<ILogger<MqttTopicSubscriber>>();
		private readonly MqttTopicSubscriber _sut;

		public MqttTopicSubscriberTests () {
			_sut = new MqttTopicSubscriber(_logger);
		}

		[Fact]
		public void Subscribe_ShouldReturnOptionsWithNoSubscriptions_WhenSubcriptionIsNone () {
			// Arrange
			var subscription = MqttSubcription.None;

			// Act
			var result = _sut.Subscribe(subscription);

			// Assert
			result.Should().NotBeNull();
			result.TopicFilters.Should().BeEmpty();
		}

		[Fact]
		public void Subscribe_ShouldReturnOptionsWithDownlinkSubscription_WhenSubcriptionHasDownlinkFlag () {
			// Arrange
			var subscription = MqttSubcription.Downlink;

			// Act
			var result = _sut.Subscribe(subscription);

			// Assert
			result.Should().NotBeNull();
			result.TopicFilters.Should().HaveCount(1);
			result.TopicFilters[0].Topic.Should().Be("downlink/#");
			_logger.Received().LogInformation("Subscribed to downlink MQTT messages from Blynk.");
		}

		[Fact]
		public void Subscribe_ShouldReturnOptionsWithUplinkSubscription_WhenSubcriptionHasUplinkFlag () {
			// Arrange
			var subscription = MqttSubcription.Uplink;

			// Act
			var result = _sut.Subscribe(subscription);

			// Assert
			result.Should().NotBeNull();
			result.TopicFilters.Should().HaveCount(1);
			result.TopicFilters[0].Topic.Should().Be("uplink/#");
			_logger.Received().LogInformation("Subscribed to uplink MQTT messages from Blynk.");
		}

		[Fact]
		public void Subscribe_ShouldReturnOptionsWithBothSubscriptions_WhenSubcriptionHasBothFlags () {
			// Arrange
			var subscription = MqttSubcription.Downlink | MqttSubcription.Uplink;

			// Act
			var result = _sut.Subscribe(subscription);

			// Assert
			result.Should().NotBeNull();
			result.TopicFilters.Should().HaveCount(2);
			result.TopicFilters[0].Topic.Should().Be("downlink/#");
			result.TopicFilters[1].Topic.Should().Be("uplink/#");
			_logger.Received().LogInformation("Subscribed to downlink MQTT messages from Blynk.");
			_logger.Received().LogInformation("Subscribed to uplink MQTT messages from Blynk.");
		}
	}
}