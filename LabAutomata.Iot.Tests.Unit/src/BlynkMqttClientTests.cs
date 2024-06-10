// TODO: these are more inline with integration testing

//using FluentAssertions;
//using LabAutomata.IoT;
//using Microsoft.Extensions.Logging;
//using MQTTnet.Client;
//using NSubstitute;

//namespace LabAutomata.Iot.Tests.Unit.src {
//	public class BlynkMqttClientTests {
//		private readonly IMqttClient _mqttClient = Substitute.For<IMqttClient>();
//		private readonly IBlynkMqttClientConfig _config = Substitute.For<IBlynkMqttClientConfig>();
//		private readonly ILogger _logger = Substitute.For<ILogger>();
//		private readonly BlynkMqttClient _sut;

//		public BlynkMqttClientTests () {
//			_sut = new BlynkMqttClient(_mqttClient, _config, _logger);
//		}

//		[Fact]
//		public async Task Connect_ShouldConnectToBroker_WhenCalled () {
//			// Arrange
//			var token = new CancellationToken();

//			// Act
//			var result = await _sut.Connect(MqttSubcription.Uplink | MqttSubcription.Downlink, token);

//			// Assert
//			await _mqttClient.Received().ConnectAsync(Arg.Any<MqttClientOptions>(), Arg.Any<CancellationToken>());
//			result.Should().BeTrue();
//		}

//		[Fact]
//		public async Task Disconnect_ShouldDisconnectFromBroker_WhenCalled () {
//			// Arrange
//			var token = new CancellationToken();

//			// Act
//			await _sut.Disconnect(token);

//			// Assert
//			await _mqttClient.Received().DisconnectAsync(cancellationToken: token);
//		}

//		[Fact]
//		public void Dispose_ShouldDisposeClient_WhenCalled () {
//			// Arrange

//			// Act
//			_sut.Dispose();

//			// Assert
//			_mqttClient.Received().Dispose();
//		}
//	}
//}