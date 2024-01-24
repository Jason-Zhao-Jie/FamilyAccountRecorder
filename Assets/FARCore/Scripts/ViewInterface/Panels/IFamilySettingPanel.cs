namespace FamilyAccountRecorder.ViewInterface.Panels {
    public interface IFamilySettingPanel : IViewPanel {
        string Name { get; set; }
        Model.Structs.FamilySettingData Setting { get; }
    }
}