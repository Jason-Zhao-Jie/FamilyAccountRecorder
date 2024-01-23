using ArmyAnt.ProcessController;

namespace FamilyAccountRecorder.Present {
    public enum Event : ulong {
        ShowPanel,
        ClosePanel,
        FamilyChanged,
    }

    public interface IEventManager : IEventManager<Event> {
        public class EventArgs : IEventArgs {
            public Event EventId { get; }

            public EventArgs(Event eventId) {
                EventId = eventId;
            }
        }
    }
}
