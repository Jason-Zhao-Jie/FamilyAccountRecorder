using ArmyAnt.ViewUtil.Components;

namespace FamilyAccountRecorder.View
{
    public class EventManager : EventManager<Present.Event>, Present.IEventManager {
        private void Awake()
        {
            ViewCenter.EventMgr = this;
        }
    }
}
