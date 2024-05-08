namespace LabAutomata.Library.src.models {
    public class Test {
        public int Id { get; set; }
        public string Name { get; set; }

        public static Test CreateInstance (Test test) {
            return new Test(test);
        }

        public static Test CreateInstance (string name) {
            return new Test(name);
        }

        private Test (Test test) {
            Name = test.Name;
        }

        private Test (string name) {
            Name = name;
        }
    }
}
