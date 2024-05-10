using System.IO;
using System.Runtime.CompilerServices;

namespace LabAutomata.Library.common {
    public static class LibC {
        public static DirectoryInfo? TryGetSolutionDirectoryInfo ([CallerFilePath] string currentPath = "") {
            var directory = new DirectoryInfo(
                currentPath ?? Directory.GetCurrentDirectory());
            while (directory != null && !directory.GetFiles("*.sln").Any()) {
                directory = directory.Parent;
            }
            return directory;
        }
    }
}
