using ErrorOr;

namespace LabAutomata.Db.common {
    /// <summary>
    /// Contains error definitions for the SsTempTest class.
    /// **NOTE**
    /// This class, generally speaking, violates the Law of Demeter... I do not care
    /// This class is strictly a tool for getting appropriate error messages in a more fluent manner
    /// </summary>
    internal static class Errors {
        public static class Crud {
            /// <summary>
            /// Returns an error indicating that the provided instance id is '0' or less than '0'.
            /// </summary>
            /// <returns>The error object.</returns>
            public static Error IdIsZeroOrLessThan (string code, string description) {
                return Error.Validation(
                    "Test.IdIsZeroOrLessThan",
                    "The provided instance id is '0' or less than '0'");
            }
        }

        public static class Db {

            /// <summary>
            /// Returns an error indicating that the entry returned 0 and needs to be debugged.
            /// </summary>
            /// <returns>The error object.</returns>
            public static Error CouldNotCreate (string code, string description) {
                return Error.Conflict(code, description);
            }

            public static Error CouldNotGet (string code, string description) {
                return Error.Conflict(code, description);
            }

            public static Error CouldNotUpsert (string code, string description) {
                return Error.Conflict(code, description);
            }

            public static Error CouldNotDelete (string code, string description) {
                return Error.Conflict(code, description);
            }
        }
    }
}
