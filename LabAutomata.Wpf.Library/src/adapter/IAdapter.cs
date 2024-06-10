namespace LabAutomata.Wpf.Library.adapter {

	public interface IAdapter {

		void Get ();
	}

	public interface IAdapter<out T> {

		T Get ();
	}
}