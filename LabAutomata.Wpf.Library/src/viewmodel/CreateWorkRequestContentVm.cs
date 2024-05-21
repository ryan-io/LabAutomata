using LabAutomata.Db.models;
using LabAutomata.Wpf.Library.common;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LabAutomata.Wpf.Library.viewmodel {
    public class CreateWorkRequestContentVm : Base {
        public string? Name {
            get => _name;
            set {
                _name = value;
                NotifyPropertyChanged();
            }
        }

        public string? Program {
            get => _program;
            set {
                _program = value;
                NotifyPropertyChanged();
            }
        }

        public string? Description {
            get => _description;
            set {
                _description = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime? StartDate {
            get => _startDate;
            set {
                _startDate = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Test> Tests { get; set; } = new();

        public ICommand TstCmd { get; set; }

        public void Reset () {
            Name = string.Empty;
            Description = string.Empty;
            Program = string.Empty;
            StartDate = default;
            Tests.Clear();
        }

        private string? _name = string.Empty;
        private string? _program = string.Empty;
        private string? _description = string.Empty;
        private DateTime? _startDate;

        public CreateWorkRequestContentVm (IServiceProvider sp) : base(sp) {
            TstCmd = new Command(o => {
                var tn = Name;
                var tp = Program;
            });
        }
    }
}