using System.IO;
using System.Runtime.CompilerServices;

namespace LabAutomata.common {
    internal static class AppC {
        public static string? GetRootPath ([CallerFilePath] string currentPath = "") {
            FileInfo fi = new FileInfo(currentPath);
            return fi.DirectoryName;
        }
    }
}
