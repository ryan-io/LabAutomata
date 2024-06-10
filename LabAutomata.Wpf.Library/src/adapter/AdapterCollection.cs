namespace LabAutomata.Wpf.Library.adapter {

	public class AdapterCollection : Dictionary<AdapterKey, IAdapter> {
	}

	[Serializable, Flags]
	public enum AdapterKey {
		DragWindow = 1 << 0
	}
}