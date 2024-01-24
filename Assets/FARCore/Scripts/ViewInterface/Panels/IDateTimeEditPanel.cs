namespace FamilyAccountRecorder.ViewInterface.Panels {
    public interface IDateTimeEditPanel : IViewPanel {
        System.DateTime Value { get; set; }
        event System.Action<System.DateTime> OnCommit;
    }
}