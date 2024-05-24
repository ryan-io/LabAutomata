using LabAutomata.Db.models;
using LabAutomata.Wpf.Library.models;

namespace LabAutomata.Wpf.Library.common {
    public static class ModelConvert {
        public static class ToDbModelList
        {
            /// <summary>
            /// Takes a collection of domain models and converts them to a list of database models.
            /// </summary>
            /// <param name="models">A list of domain models to converted</param>
            /// <returns>A list of db models</returns>
            public static List<T> With<T>(List<DomainModel<T>> models) where T : LabModel {
                var output = new List<T>();

                foreach (var domainModel in models) {
                    domainModel.Validate();
                    output.Add(domainModel.Create());
                }

                return output;
            }
        }
    }
}
