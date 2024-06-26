using LabAutomata.IoT;
using System.Reflection;

namespace LabAutomata.Wpf.Library.common {

	public static class Extensions {
		public static DateTime ToDateTime (this MqttDht22Payload payload) {
			var output = new DateTime(
				payload.Year,
				payload.Month,
				payload.Day,
				payload.Hour,
				payload.Minute,
				payload.Second);

			return output;
		}

		public static IEnumerable<Type> OfBase (this Type type) {
			Type t = type;

			while (true) {
				t = t.BaseType!;
				if (t == null!) break;
				yield return t;
			}
		}

		public static bool IsOfAnyBase (this Type type, Func<Type, bool> predicate) {
			return type.OfBase().Any(predicate);
		}

		public static bool IsOfBase (this Type type, Type baseType) {
			return type.DeclaringType == baseType;
		}

		public static IEnumerable<Type> GetSubclassOf<T> (this Assembly asm) {
			return asm.GetTypes().Where(t => t.IsSubclassOf(typeof(T)) && !t.IsAbstract);
		}
	}
}