using FamilyAccountRecorder.View;

using static FamilyAccountRecorder.Present.EventArgs_ShowPanel;

namespace FamilyAccountRecorder
{
    public static class ViewCenter
    {
        public static EventManager EventMgr { get; set; }

        public static void Init()
        {
            CoreCenter.Init();
            EventMgr.NotifySync(new Present.EventArgs_ShowPanel(PanelType.FamilyManager, PanelLayer.Panel));
        }
    }
}
