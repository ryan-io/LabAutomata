using System.Text;

namespace LabAutomata.Wpf.Library.common;

public class VmIdExtractor : IVmIdExtractor {
	public string Extract (string obj) {
		_sb.Clear();

		_sb.Append(obj.Remove(obj.Length - 2));
		_sb.Append(SubVmSuffix);
		return _sb.ToString();
	}

	private const string SubVmSuffix = "ContentVm";
	private readonly StringBuilder _sb = new();
}

public interface IVmIdExtractor {
	string Extract (string obj);
}