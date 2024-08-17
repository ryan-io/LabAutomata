namespace LabAutomata.DataAccess.common;

public class ReplaceApostopheWithQuote {
	public string Modify (ref string str) {
		// allocate the total number of chars in 'str' on the stack

		Span<char> span = stackalloc char[str.Length];
		str.CopyTo(span);
		span.Replace('\'', '"');
		return span.ToString();
	}
}