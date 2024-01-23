namespace FamilyAccountRecorder.Present {
    public class EventArgs_ClosePanel : IEventManager.EventArgs {
        public EventArgs_ShowPanel.PanelType Type { get; }

        public EventArgs_ClosePanel(EventArgs_ShowPanel.PanelType type) :base(Event.ShowPanel) {
            Type = type;
        }
    }
}
