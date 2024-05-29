using LabAutomata.Db.models;
using LabAutomata.Db.repository;
using LabAutomata.Wpf.Library.adapter;
using LabAutomata.Wpf.Library.commands;
using LabAutomata.Wpf.Library.common;
using LabAutomata.Wpf.Library.models;
using Microsoft.Extensions.Logging;
using System.Windows.Input;
using System.Windows.Threading;

namespace LabAutomata.Wpf.Library.viewmodel {
    public interface ICreateWorkRequestContentVm {
        ICommand CreateDbModelCmd { get; }
        ICommand ResetDbModel { get; }
        WorkRequestDomainModel Model { get; set; }
        string NameEmptyBox { get; set; }
        string ProgramEmptyBox { get; set; }
        string DescEmptyBox { get; set; }
        string StartEmptyBox { get; set; }

        /// <summary>
        /// Resets the properties of the CreateWorkRequestContentVm to their default values.
        /// </summary>
        void Reset (object? sender);
    }

    public class CreateWorkRequestContentVm : Base, ICreateWorkRequestContentVm {
        public ICommand CreateDbModelCmd { get; }

        public ICommand ResetDbModel { get; }

        public WorkRequestDomainModel Model { get; set; } = new();

        /// <summary>
        /// Resets the properties of the CreateWorkRequestContentVm to their default values.
        /// </summary>
        public override void Reset (object? sender) {
            Model.Reset();
            NotifyPropertyChanged(nameof(Model));
        }

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

        /// There is a dependence on the actual repository
        public CreateWorkRequestContentVm (IRepository<WorkRequest> repository, IAdapter<Dispatcher> dA, ILogger? logger = default) : base(logger) {
            CreateDbModelCmd = new CreateWrDbModelCmd(dA, repository, () => Reset(CreateDbModelCmd), logger);
            ResetDbModel = new Command(Reset);
        }

        private string _nameEmptyBox = "Enter a name";
        private string _programEmptyBox = "Enter a program";
        private string _descEmptyBox = "Enter a description for the work request";
        private string _startEmptyBox = "Enter a start on date";
    }
}