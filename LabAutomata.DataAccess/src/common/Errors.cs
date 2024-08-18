using ErrorOr;
using rbcl;

namespace LabAutomata.DataAccess.common {

	/// <summary>
	/// Contains error definitions for the SsTempTest class.
	/// **NOTE**
	/// This class, generally speaking, violates the Law of Demeter... I do not care
	/// This class is strictly a tool for getting appropriate error messages in a more fluent manner
	/// </summary>
	internal static class Errors {
		internal static class Db {

			/// <summary>
			/// Returns an error indicating that the entry returned 0 and needs to be debugged.
			/// </summary>
			/// <returns>The error object.</returns>
			internal static Error CouldNotCreate (string code, string description) {
				return Error.Conflict(code, description);
			}

			internal static Error CouldNotGet (string code, string description) {
				return Error.Conflict(code, description);
			}

			internal static Error CouldNotUpsert (string code, string description) {
				return Error.Conflict(code, description);
			}

			internal static Error CouldNotDelete (string code, string description) {
				return Error.Conflict(code, description);
			}

			internal static Error CouldNotGetAll (string code, string description) {
				return Error.NotFound(code, description);
			}
		}

		internal static class Validate {
			internal static List<Error> InvalidJson (JsonValidationErrorMap errors) {
				var output = new List<Error>();

				foreach (var pair in errors) {
					foreach (var errorMsg in pair.Value) {
						var e = Error.Validation(nameof(InvalidJson), errorMsg);
						output.Add(e);
					}
				}

				return output;
			}

			internal static Error StringIsNullOrEmpty (string? code = default, string? description = default) {
				if (string.IsNullOrWhiteSpace(code)) {
					code = nameof(StringIsNullOrEmpty);
				}

				if (string.IsNullOrWhiteSpace(description)) {
					description = "The provided string was either null or contained no characters.";
				}

				return Error.Validation(code, description);
			}
		}
	}
}