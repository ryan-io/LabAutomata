namespace LabAutomata.Library.common {
    /// <summary>
    ///   A singleton class. Provides a single static instance of class type T.
    ///  <para>Usage: public class MyClass : Singleton&lt;MyClass&gt; { }</para>
    ///  Can be accessed from anywhere using MyClass.Instance
    ///  to riot-bcl.
    /// </summary>
    /// <typeparam name="T">Type instance create a Singleton for</typeparam>
    public class Singleton<T> where T : class, new() {
        public static T Instance {
            get {
                lock (_mutex)
                    return _instance.Value;
            }
        }

        private static readonly object _mutex = new();
        private static readonly Lazy<T> _instance = new(() => new T());

        public Singleton () {

        }
    }
}
