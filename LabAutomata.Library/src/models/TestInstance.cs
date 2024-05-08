namespace LabAutomata.Library.models {
    public class TestInstance : LabModel {
        public TestInstance (Test test) {
            Test = test;
        }

        public int InstanceId { get; set; }

        public Test Test { get; set; }
    }
}
