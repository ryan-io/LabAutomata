namespace LabAutomata.Library.common {
    public class JsonTestInstanceIdGenerator : ITestInstanceIdGenerator {
        private int CurrentId { get; set; }

        public int GetNext () { CurrentId++; return CurrentId; }

        public JsonTestInstanceIdGenerator () {

        }

        private const string XmlName = "testinstance_id_cache";
    }

    public interface ITestInstanceIdGenerator {
        int GetNext ();
    }
}
