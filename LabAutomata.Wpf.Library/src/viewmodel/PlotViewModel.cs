using LabAutomata.IoT;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SkiaSharp;
using System.Collections.ObjectModel;

namespace LabAutomata.Wpf.Library.viewmodel {

	public class PlotViewModel : Base {
		public ObservableCollection<ISeries> Series { get; set; }

		public Axis[] XAxes { get; set; } =
		[
			new()
			{
				Name = "Timestamp",
				LabelsPaint = new SolidColorPaint(SKColors.Black)
			}
		];

		public Axis[] YAxes { get; set; } =
		[
			new()
			{
				Name = "Temperature",
				LabelsPaint = new SolidColorPaint(SKColors.Black)
			}
		];

		public PlotViewModel (IBlynkMqttClient blynkClient, ILogger logger) {
			_blynkMqttClient = blynkClient;
			_logger = logger;

			_observableValues = new ObservableCollection<ObservablePoint>();

			Series = new ObservableCollection<ISeries>()
			{
				new LineSeries<ObservablePoint>()
				{
					Values = _observableValues,
					Fill = null
				}
			};

			var response = new JsonInterpretation();

			blynkClient.MessageReceived += args => {
				var output = response.Interpret(args);
				if (output.IsError || output.ResponseObject == null)
					return;

				// this try-catch needs to be here... especially for DHT11 & DHT22 temp/humidity sensors
				// if a value is output as NaN, this technically returns an object that is 'null', but the
				//		error bit is not flipped.
				// to catch this error, this try-catch is in place to simply swallow the exceptions
				// this may be partially due to the sampling rate being defined as 1sample/2sec
				// 9-June-2024 -> updated .ino to change the sampling rate to 1sample/3sec
				// TODO: more appropriate handling of errors
				try {
					var payload = JsonConvert.DeserializeObject<MqttDht22Payload>(output.ResponseObject);
					_observableValues.Add(new ObservablePoint(payload.TimeStamp, payload.Temperature));
				}
				catch (Exception ex) {
					_logger.LogError(ex.Message);
				}
			};
		}

		private readonly IBlynkMqttClient _blynkMqttClient;
		private readonly ILogger _logger;
		private readonly ObservableCollection<ObservablePoint> _observableValues;
	}
}