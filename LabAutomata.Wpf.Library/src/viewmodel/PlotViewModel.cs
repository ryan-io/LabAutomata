using LabAutomata.IoT;
using LabAutomata.Wpf.Library.common;
using LabAutomata.Wpf.Library.contracts;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Microsoft.Extensions.Logging;
using SkiaSharp;
using System.Collections.ObjectModel;

namespace LabAutomata.Wpf.Library.viewmodel {
	public class PlotViewModel : Base {
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

		public PlotViewModel (IDht22PayloadData dhtPayloadData, ILogger logger) {
			XAxes = [new DateTimeAxis(TimeSpan.FromDays(1), date => date.ToString("MM dd"))];

			_logger = logger;
			_dht22PayloadData = dhtPayloadData;
			_observableValues = new ObservableCollection<DateTimePoint>();

			Series = new ObservableCollection<ISeries>()
			{
				new LineSeries<DateTimePoint>()
				{
					Values = _observableValues,
					Fill = null
				}
			};

			_dht22PayloadData.PayloadDeserialized += GetPayloadData;
		}

		protected override void InternalDispose () {
			_dht22PayloadData.PayloadDeserialized -= GetPayloadData;
		}

		void GetPayloadData (MqttDht22Payload payload) {
			var date = payload.ToDateTime();
			_observableValues.Add(new DateTimePoint(date, payload.Temperature));
		}

		private readonly ILogger _logger;
		private readonly ObservableCollection<DateTimePoint> _observableValues;
		private readonly IDht22PayloadData _dht22PayloadData;
	}
}