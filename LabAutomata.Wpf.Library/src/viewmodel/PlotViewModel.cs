using LabAutomata.IoT;
using LabAutomata.Wpf.Library.common;
using LabAutomata.Wpf.Library.contracts;
using LabAutomata.Wpf.Library.mediator_stores;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Microsoft.Extensions.Logging;
using SkiaSharp;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace LabAutomata.Wpf.Library.viewmodel {
	public class PlotViewModel : Base {
		public string Title { get; set; } = "Unnamed Plot";

		public ObservableCollection<ISeries> Series { get; set; }

		public Axis[] XAxes { get; set; }

		public Axis[] YAxes { get; set; } =
		[
			new()
			{
				Name = "Temperature",
				LabelsPaint = new SolidColorPaint(SKColors.Black)
			}
		];

		public void HandleSelectedPlotChange (object? sender, PropertyChangedEventArgs e) {
			if (string.Equals(e.PropertyName, "SelectedPlot")) {
				// logic
			}
		}

		public PlotViewModel (IDht22PayloadData dhtPayloadData, IDhtSensorDataWriter dataWriter, ILogger logger) {
			//XAxes = [new() {
			//	Name = "Date & Time (UTC)",
			//	LabelsPaint = new SolidColorPaint(SKColors.Black),

			//}];

			XAxes = [new DateTimeAxis(TimeSpan.FromDays(1), date => date.ToString("MM dd"))
			{
				Name = "Date & Time (UTC)",
				LabelsPaint = new SolidColorPaint(SKColors.Black)
			}];

			_logger = logger;
			_dht22PayloadData = dhtPayloadData;
			_dataWriter = dataWriter;
			_observableValues = new ObservableCollection<DateTimePoint>();

			Series = new ObservableCollection<ISeries>()
			{
				new LineSeries<DateTimePoint>()
				{
					Values = _observableValues,
					Stroke = new SolidColorPaint(SKColors.Black),
					GeometryStroke= new SolidColorPaint(SKColors.Goldenrod, 2),
					GeometryFill = null
				}
			};
		}

		public override void Load () {
			_dht22PayloadData.PayloadDeserialized += GetPayloadData;

		}

		protected override void InternalDispose () {
			_dht22PayloadData.PayloadDeserialized -= GetPayloadData;
		}


		private int counter = 0;

		void GetPayloadData (MqttDht22Payload payload) {
			var date = payload.ToDateTime();
			_observableValues.Add(new DateTimePoint(date, payload.Temperature));
			_logger.LogInformation("Received payloed {counter}", counter);
			counter++;
		}

		private readonly ILogger _logger;
		private readonly ObservableCollection<DateTimePoint> _observableValues;
		private readonly IDht22PayloadData _dht22PayloadData;
		private readonly IDhtSensorDataWriter _dataWriter;
	}
}