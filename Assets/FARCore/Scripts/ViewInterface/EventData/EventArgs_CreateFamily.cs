using FamilyAccountRecorder.Model.Structs;

namespace FamilyAccountRecorder.ViewInterface {
    public class EventArgs_CreateFamily : IEventManager.EventArgs {
        public FamilySettingData Data { get; }

        public EventArgs_CreateFamily(FamilySettingData data) :base(Event.ShowPanel) {
            Data = data;
        }
    }
}
