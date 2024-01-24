using FamilyAccountRecorder.Model.Structs;

using System;

namespace FamilyAccountRecorder.ViewInterface {
    public class EventArgs_ShowPanel : IEventManager.EventArgs {
        public IViewPanel.PanelType Type { get; }
        public IViewPanel.PanelLayer Layer { get; }

        public EventArgs_ShowPanel(IViewPanel.PanelType type, IViewPanel.PanelLayer layer) : base(Event.ShowPanel) {
            Type = type;
            Layer = layer;
        }
    }

    public class EventArgs_ShowPanel<T> : EventArgs_ShowPanel {
        public T Data { get; set; }
        public EventArgs_ShowPanel(IViewPanel.PanelType type, IViewPanel.PanelLayer layer) : base(type, layer) { }
    }

    public class EventArgs_ShowPanelWithResult<T> : EventArgs_ShowPanel<T> {
        public Action<T> OnCommit { get; set; }
        public EventArgs_ShowPanelWithResult(IViewPanel.PanelType type, IViewPanel.PanelLayer layer) : base(type, layer) { }
    }

}
