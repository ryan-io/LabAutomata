using LabAutomata.Db.models;
using LabAutomata.Wpf.Library.adapter;
using LabAutomata.Wpf.Library.commands;
using LabAutomata.Wpf.Library.common;
using LabAutomata.Wpf.Library.domain_models;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Threading;

namespace LabAutomata.Wpf.Library.viewmodel {

	public class CreateWorkRequestContentVm : Base {
		public ICommand CreateDbModelCmd { get; }

		public ICommand ResetDbModel { get; }

		public WorkRequestDomainModel Model { get; set; } = new();

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

		public override async Task LoadAsync (CancellationToken token = default) {
			//var m = await _manufacturerRepository.GetAll(token);
			//Manufacturers = new ObservableCollection<Manufacturer>(m);
		}

		/// There is a dependence on the actual wrRepository
		public CreateWorkRequestContentVm (
			IRepository<WorkRequest> wrRepository,
			IRepository<Manufacturer> manRepository,
			IAdapter<Dispatcher> dA,
			ILogger? logger = default)
				: base(logger) {
			CreateDbModelCmd = new CreateWrDbModelCommand(dA, wrRepository, () => Reset(CreateDbModelCmd), logger);
			ResetDbModel = new Command(Reset);
			_manufacturerRepository = manRepository;
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
		private readonly IRepository<Manufacturer> _manufacturerRepository;
	}
}