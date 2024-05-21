using LabAutomata.Db.models;

namespace LabAutomata.Wpf.Library.viewmodel {
    public class NewWorkRequestFormVm (IServiceProvider sp) : FormBase(sp) {
        public string? Name { get; set; } = string.Empty;
        public string? Program { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public DateTime? StartDate { get; set; }
        public List<Test> Tests { get; set; } = new();

        public override void Reset () {
            Name = string.Empty;
            Description = string.Empty;
            Program = string.Empty;
            StartDate = default;
            Tests.Clear();
        }
    }
}
