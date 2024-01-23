namespace FamilyAccountRecorder.Present {
    public class EventArgs_ShowPanel : IEventManager.EventArgs {
        public enum PanelType {
            DropSelect,
            FamilyManager,
            FamilySetting,
        }

        public enum PanelLayer {
            Back,
            FullScreen,
            Panel,
            Popup,
            Float,
            To,
        }

        public PanelType Type { get; }
        public PanelLayer Layer { get; }
        public object Data { get; }

        public EventArgs_ShowPanel(PanelType type, PanelLayer layer, object data = null) :base(Event.ShowPanel) {
            Type = type;
            Layer = layer;
            Data = data;
        }
    }
}
