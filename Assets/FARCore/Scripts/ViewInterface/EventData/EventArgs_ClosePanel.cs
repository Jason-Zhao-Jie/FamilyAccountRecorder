namespace FamilyAccountRecorder.ViewInterface {
    public class EventArgs_ClosePanel : IEventManager.EventArgs {
        public IViewPanel.PanelType Type { get; }

        public EventArgs_ClosePanel(IViewPanel.PanelType type) :base(Event.ShowPanel) {
            Type = type;
        }
    }
}
