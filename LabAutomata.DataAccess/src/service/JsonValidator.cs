using ErrorOr;
using LabAutomata.DataAccess.common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LabAutomata.DataAccess.service;


/// <summary>
/// Internally invokes 'JObject.Parse' on the provided string, 'json'
/// There is a try-catch block to handle 'JsonReaderException' exception
/// The dependency on the ErrorOr package allows a discriminated return type
///		that contains an error message and state
/// Typical JSON formatting is expressed as the following (example):
/// "{
///		"Id":1,
///		"Name": "Test",
///		"Payload":"12, 323, 232"
/// }"
/// For this method, the double parenthesis (") need to be replaced with single parenthesis (')
/// "{
///		'Id':1,
///		'Name': 'Test',
///		'Payload': '12, 323, 232'
/// }"
/// </summary>
public interface IJsonValidator {
	ErrorOr<bool> Validate (string json);
}

/// <inheritdoc/>>
public class JsonValidator : IJsonValidator {
	public ErrorOr<bool> Validate (string json) {
		_errors.Clear();
		if (string.IsNullOrWhiteSpace(json)) {
			_errors.Add(Errors.Validate.StringIsNullOrEmpty());
		}

		try {
			JObject.Parse(json);
		}
		catch (JsonReaderException e) {
			_errors.Add(Errors.Validate.InvalidJsonString(description: e.Message));
		}

		if (_errors.Any()) {
			return ErrorOr<bool>.From(_errors);
		}

		return true;
	}

	private readonly List<Error> _errors = [];
}