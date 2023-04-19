using FamilyAccountRecorder.View;
using FamilyAccountRecorder.View.Constants;

namespace FamilyAccountRecorder
{
    public static class ViewCenter
    {
        public static EventManager EventMgr { get; set; }

        public static void Init()
        {
            CoreCenter.Init();
            EventMgr.Notify(Event.ShowPanel, PanelType.FamilyManager, PanelLayer.Panel);
        }
    }
}
