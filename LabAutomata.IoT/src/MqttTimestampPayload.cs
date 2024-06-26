namespace LabAutomata.IoT;

public readonly struct MqttTimestampPayload(int year, int month, int day, int hour, int minute, int second)
{
	public int Year { get; init; } = year;
	public int Month { get; init; } = month;
	public int Day { get; init; } = day;
	public int Hour { get; init; } = hour;
	public int Minute { get; init; } = minute;
	public int Second { get; init; } = second;
}