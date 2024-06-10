namespace LabAutomata.Db.models;

public class LabDataContainer : LabModel {
	public ICollection<LabJsonData> Data { get; init; }

}