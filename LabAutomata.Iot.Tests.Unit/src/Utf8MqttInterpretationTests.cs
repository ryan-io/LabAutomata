using FluentAssertions;
using LabAutomata.IoT;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Packets;

namespace LabAutomata.Iot.Tests.Unit {

	public class Utf8MqttInterpretationTests {
		private readonly Utf8MqttInterpretation _sut;

		public Utf8MqttInterpretationTests () {
			_sut = new Utf8MqttInterpretation();
		}

		[Fact]
		public void Interpret_ShouldReturnFloatValue_WhenPayloadCanBeParsed () {
			// Arrange
			// UTF8 literal: "1.23"u8.ToArray();
			ReadOnlySpan<byte> test = "1.23"u8;
			var payload = new byte[] { 49, 46, 50, 51 }; // "1.23" in ASCII-> implicit char to int
			ReadOnlySpan<byte> payloadSpan = new ReadOnlySpan<byte>(payload);
			var applicationMessage = new MqttApplicationMessage {
				//TODO: I'm not sure if this is a breaking API change
				PayloadSegment = payload
			};

			var eventArgs = new MqttApplicationMessageReceivedEventArgs("", applicationMessage, new MqttPublishPacket(), null);

			// Act
			var result = _sut.Interpret(eventArgs);

			// Assert
			result.Should().Be(result);
			result.ResponseObject.Should().Be(1.23f);
		}
	}
}