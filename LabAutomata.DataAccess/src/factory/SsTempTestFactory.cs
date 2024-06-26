﻿using ErrorOr;
using LabAutomata.Db.models;

namespace LabAutomata.DataAccess.factory {
	//TODO: define additional factory methods that put ALL instances into a valid state
	public class WorkstationFactory {
		/// <summary>
		/// Takes a dto for a workstation domain model and transforms it into
		/// a discriminated union; either an error or a db model for workstation
		/// </summary>
		/// <param name="dto">data transfer object for domain to db model</param>
		/// <returns>discriminated union; an error or the db model for workstation</returns>
		//public WorkstationRequest GetNew (
		//	string name = "",
		//	int stationNumber = -1,
		//	string description = "",
		//	Location? locatoin = default,
		//	ICollection<WorkstationType> types = default,
		//	ICollection<Equipment> equipment = default,
		//	ICollection<Test> tests = default) {

		//	return new WorkstationDto(n)

		//}

		//private ErrorOr<Workstation> ValidateProperties (WorkstationRequest dto) {
		//	var errors = new List<Error>();


		//	if () {
		//		errors.Add(Errors.Crud.IdIsZeroOrLessThan(TestIdIsZeroOrLessThanCode, TestIdIsZeroOrLessThanMsg));
		//	}

		//	if (errors.Any()) return errors;

		//	return new ErrorOr<Workstation>() {

		//	};
		//}
	}

	/// <summary>
	/// Factory class for creating instances of Test.
	/// </summary>
	public class SsTempTestFactory {

		/// <summary>
		/// Creates a new instance of Test using the provided instanceId.
		/// </summary>
		/// <param name="instanceId">The instance ID for the Test.</param>
		/// <param name="testName">Name of the test</param>
		/// <returns>An ErrorOr object containing either the created Test instance or a list of errors.</returns>
		public ErrorOr<Test> Create (int instanceId, TestType testType) {
			return Validate(instanceId);
		}

		public ErrorOr<Test> CreateForDeletion (int id) {
			return ValidateDeletion(id);
		}

		/// <summary>
		/// Clones the provided Test instance with a new ID.
		/// </summary>
		/// <param name="id">The ID for the cloned Test.</param>
		/// <param name="toClone">The Test instance to clone.</param>
		/// <returns>An ErrorOr object containing either the cloned Test instance or a list of errors.</returns>
		public ErrorOr<Test> CloneWithId (int id, Test toClone) {
			return ValidateClone(id, toClone);
		}

		/// <summary>
		/// Validates the provided instanceId and creates a new instance of Test if the validation passes.
		/// </summary>
		/// <param name="instanceId">The instance ID for the Test.</param>
		/// <returns>An ErrorOr object containing either the created Test instance or a list of errors.</returns>
		private ErrorOr<Test> Validate (int instanceId) {
			var errors = ValidationLogic(instanceId);

			if (errors.Any()) return errors;
			return new Test("test", instanceId);
		}

		/// <summary>
		/// Validates the provided instanceId and creates a new instance of Test if the validation passes.
		/// </summary>
		/// <param name="id">The ID for the Test to be cloned.</param>
		/// <param name="clone">'Clone' of the model to upsert</param>
		/// <returns>An ErrorOr object containing either the cloned Test instance or a list of errors.</returns>
		private ErrorOr<Test> ValidateClone (int id, Test clone) {
			var errors = new List<Error>(); //TODO: actual validation logic for cloning models should be implemented

			if (errors.Any()) return errors;
			return new Test(id, clone);
		}

		/// <summary>
		/// Validates the provided ID and creates a new instance of Test with the given ID for deletion.
		/// </summary>
		/// <param name="id">The ID for the Test to be deleted.</param>
		/// <returns>An ErrorOr object containing either the created Test instance or a list of errors.</returns>
		private ErrorOr<Test> ValidateDeletion (int id) {
			var errors = ValidationLogic(id);
			if (errors.Any()) return errors;

			// not the most elegant passing '0' into the constructor...
			return new Test { Id = id };
		}

		/// <summary>
		/// Validates the provided instanceId and creates a new instance of Test if the validation passes.
		/// </summary>
		/// <param name="instanceId">The instance ID for the Test.</param>
		/// <returns>A list of errors encountered during validation.</returns>
		private List<Error> ValidationLogic (int instanceId) {
			List<Error> errors = new();

			if (instanceId <= 0) {
				//errors.Add(Errors.Crud.IdIsZeroOrLessThan(TestIdIsZeroOrLessThanCode, TestIdIsZeroOrLessThanMsg));
			}

			return errors;
		}

		private readonly string TestIdIsZeroOrLessThanCode = "Test.IdIsZeroOrLessThan";
		private readonly string TestIdIsZeroOrLessThanMsg = "The provided instance id is '0' or less than '0'";
	}
}