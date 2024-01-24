namespace FamilyAccountRecorder.ViewInterface.Panels {
    public interface IDialogPanel : IViewPanel {
        View.Prefab.DialogPanel.EventArgs_ShowPanel_DialogPanel.DialogData DialogData { set; }
        event System.Func<bool> OnLeftClick;
        event System.Func<bool> OnMidClick;
        event System.Func<bool> OnRightClick;
    }
}