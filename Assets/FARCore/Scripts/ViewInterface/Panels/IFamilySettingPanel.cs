namespace FamilyAccountRecorder.ViewInterface.Panels {
    public interface IFamilySettingPanel : IViewPanel {
        Model.Structs.FamilySettingData Data { get; set; }
        event System.Action<Model.Structs.FamilySettingData> OnCommit;
    }
}