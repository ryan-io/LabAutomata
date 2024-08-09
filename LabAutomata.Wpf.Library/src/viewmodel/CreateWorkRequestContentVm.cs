using LabAutomata.Db.models;
using LabAutomata.Wpf.Library.adapter;
using LabAutomata.Wpf.Library.common;
using LabAutomata.Wpf.Library.domain_models;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Threading;

namespace LabAutomata.Wpf.Library.viewmodel {

	public class CreateWorkRequestContentVm : Base {
		public ICommand CreateDbModelCmd { get; } = null!;

		public ICommand ResetDbModel { get; }

		public WorkRequestDomain Model { get; set; } = null!;

		public ObservableCollection<Manufacturer> Manufacturers { get; set; } = null!;

		public string NameEmptyBox {
			get => _nameEmptyBox;
			set { _nameEmptyBox = value; NotifyPropertyChanged(); }
		}

		public string ProgramEmptyBox {
			get => _programEmptyBox;
			set { _programEmptyBox = value; NotifyPropertyChanged(); }
		}

		public string DescEmptyBox {
			get => _descEmptyBox;
			set { _descEmptyBox = value; NotifyPropertyChanged(); }
		}

		public string StartEmptyBox {
			get => _startEmptyBox;
			set { _startEmptyBox = value; NotifyPropertyChanged(); }
		}

		//TODO: implement this method properly
		public override Task LoadAsync (CancellationToken token = default) {
			//var m = await _manufacturerRepository.GetAll(token);
			//Manufacturers = new ObservableCollection<Manufacturer>(m);
			return Task.CompletedTask;
		}

		/// There is a dependence on the actual wrRepository
		public CreateWorkRequestContentVm (
			IAdapter<Dispatcher> dA,
			ILogger? logger = default)
				: base(logger) {
			//CreateDbModelCmd = new CreateWrDbModelCommand(dA, () => Reset(CreateDbModelCmd), logger);
			ResetDbModel = new Command(Reset);
		}

		/// <summary>
		/// Resets the properties of the CreateWorkRequestContentVm to their default values.
		/// </summary>
		private void Reset (object? sender) {
			Model.Reset();
			NotifyPropertyChanged(nameof(Model));
		}


		private string _nameEmptyBox = "Enter a name";
		private string _programEmptyBox = "Enter a program";
		private string _descEmptyBox = "Enter a description for the work request";
		private string _startEmptyBox = "Enter a start on date";
	}
}