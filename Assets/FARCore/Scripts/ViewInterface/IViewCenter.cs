using static FamilyAccountRecorder.ViewInterface.IViewPanel;

namespace FamilyAccountRecorder.ViewInterface {
    public interface IViewCenter {
        IViewPanel ShowPanel(EventArgs_ShowPanel args);
        bool ClosePanel(PanelType type);
    }
}