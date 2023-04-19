using ArmyAnt.ViewUtil.Components;

namespace FamilyAccountRecorder.View
{
    public class EventManager : EventPlayer<Constants.Event, ulong>
    {
        protected override void Awake()
        {
            base.Awake();
            ViewCenter.EventMgr = this;
        }
    }
}
