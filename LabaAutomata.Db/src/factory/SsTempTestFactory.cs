using ErrorOr;
using LabAutomata.Db.common;
using LabAutomata.Db.models;

namespace LabAutomata.Db.factory {
    /// <summary>
    /// Factory class for creating instances of SteadyStateTemperatureTest.
    /// </summary>
    public static class SsTempTestFactory {
        /// <summary>
        /// Creates a new instance of SteadyStateTemperatureTest using the provided instanceId.
        /// </summary>
        /// <param name="instanceId">The instance ID for the SteadyStateTemperatureTest.</param>
        /// <returns>An ErrorOr object containing either the created SteadyStateTemperatureTest instance or a list of errors.</returns>
        public static ErrorOr<SteadyStateTemperatureTest> Create (int instanceId) {
            return Validate(instanceId);
        }

        /// <summary>
        /// Validates the provided instanceId and creates a new instance of SteadyStateTemperatureTest if the validation passes.
        /// </summary>
        /// <param name="instanceId">The instance ID for the SteadyStateTemperatureTest.</param>
        /// <returns>An ErrorOr object containing either the created SteadyStateTemperatureTest instance or a list of errors.</returns>
        static ErrorOr<SteadyStateTemperatureTest> Validate (int instanceId) {
            List<Error> errors = new();

            if (instanceId <= 0) {
                errors.Add(Errors.Crud.IdIsZeroOrLessThan(TestIdIsZeroOrLessThanCode, TestIdIsZeroOrLessThanMsg));
            }

            if (errors.Any()) return errors;
            return new SteadyStateTemperatureTest(instanceId);
        }

        private static readonly string TestIdIsZeroOrLessThanCode = "Test.IdIsZeroOrLessThan";
        private static readonly string TestIdIsZeroOrLessThanMsg = "The provided instance id is '0' or less than '0'";
    }
}
