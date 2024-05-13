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

        public static ErrorOr<SteadyStateTemperatureTest> CreateForDeletion (int id) {
            return ValidateDeletion(id);
        }

        /// <summary>
        /// Clones the provided SteadyStateTemperatureTest instance with a new ID.
        /// </summary>
        /// <param name="id">The ID for the cloned SteadyStateTemperatureTest.</param>
        /// <param name="toClone">The SteadyStateTemperatureTest instance to clone.</param>
        /// <returns>An ErrorOr object containing either the cloned SteadyStateTemperatureTest instance or a list of errors.</returns>
        public static ErrorOr<SteadyStateTemperatureTest> CloneWithId (int id, SteadyStateTemperatureTest toClone) {
            return ValidateClone(id, toClone);
        }

        /// <summary>
        /// Validates the provided instanceId and creates a new instance of SteadyStateTemperatureTest if the validation passes.
        /// </summary>
        /// <param name="instanceId">The instance ID for the SteadyStateTemperatureTest.</param>
        /// <returns>An ErrorOr object containing either the created SteadyStateTemperatureTest instance or a list of errors.</returns>
        static ErrorOr<SteadyStateTemperatureTest> Validate (int instanceId) {
            var errors = ValidationLogic(instanceId);

            if (errors.Any()) return errors;
            return new SteadyStateTemperatureTest(instanceId);
        }

        /// <summary>
        /// Validates the provided instanceId and creates a new instance of SteadyStateTemperatureTest if the validation passes.
        /// </summary>
        /// <param name="id">The ID for the SteadyStateTemperatureTest to be cloned.</param>
        /// <param name="clone">'Clone' of the model to upsert</param>
        /// <returns>An ErrorOr object containing either the cloned SteadyStateTemperatureTest instance or a list of errors.</returns>
        static ErrorOr<SteadyStateTemperatureTest> ValidateClone (int id, SteadyStateTemperatureTest clone) {
            var errors = new List<Error>(); //TODO: actual validation logic for cloning models should be implemented

            if (errors.Any()) return errors;
            return new SteadyStateTemperatureTest(id, clone);
        }

        /// <summary>
        /// Validates the provided ID and creates a new instance of SteadyStateTemperatureTest with the given ID for deletion.
        /// </summary>
        /// <param name="id">The ID for the SteadyStateTemperatureTest to be deleted.</param>
        /// <returns>An ErrorOr object containing either the created SteadyStateTemperatureTest instance or a list of errors.</returns>
        static ErrorOr<SteadyStateTemperatureTest> ValidateDeletion (int id) {
            var errors = ValidationLogic(id);
            if (errors.Any()) return errors;

            // not the most elegant passing '0' into the constructor...
            return new SteadyStateTemperatureTest(0) { Id = id };
        }

        /// <summary>
        /// Validates the provided instanceId and creates a new instance of SteadyStateTemperatureTest if the validation passes.
        /// </summary>
        /// <param name="instanceId">The instance ID for the SteadyStateTemperatureTest.</param>
        /// <returns>A list of errors encountered during validation.</returns>
        private static List<Error> ValidationLogic (int instanceId) {
            List<Error> errors = new();

            if (instanceId <= 0) {
                errors.Add(Errors.Crud.IdIsZeroOrLessThan(TestIdIsZeroOrLessThanCode, TestIdIsZeroOrLessThanMsg));
            }

            return errors;
        }


        private static readonly string TestIdIsZeroOrLessThanCode = "Test.IdIsZeroOrLessThan";
        private static readonly string TestIdIsZeroOrLessThanMsg = "The provided instance id is '0' or less than '0'";
    }
}
