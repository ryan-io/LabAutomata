using LabAutomata.Wpf.Library.viewmodel;
using System.IO;
using System.Runtime.CompilerServices;

namespace LabAutomata.common {
    /// <summary>
    /// Static clr objects used throughout the application
    /// </summary>
    internal class AppC {
        public static string NavVm = nameof(NavigationVm);
        public static string HomeVm = nameof(Wpf.Library.viewmodel.HomeVm);
        public static string WrVm = nameof(WorkRequestVm);
        public static string CwrVm = nameof(CreateWorkRequestVm);
        public static string WsVm = nameof(WorkstationsVm);
        public static string EiVm = nameof(EquipmentItemsVm);

        public static string? GetRootPath ([CallerFilePath] string currentPath = "") {
            FileInfo fi = new FileInfo(currentPath);
            return fi.DirectoryName;
        }
    }
}
