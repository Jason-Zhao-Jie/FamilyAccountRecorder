using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyAccountRecorder.View.Constants
{
    public enum Event : ulong
    {
        ShowPanel,
        ClosePanel,
    }

    public static class PanelType
    {
        public static ulong DropSelect = 0;
        public static ulong FamilyManager = 1;
    }

    public static class PanelLayer
    {
        public static ulong Back = 0;
        public static ulong FullScreen = 1;
        public static ulong Panel = 2;
        public static ulong Popup = 3;
        public static ulong Float = 4;
        public static ulong To = 5;
    }

    public static class DropType
    {
        public static ushort Local = 0;
        public static ushort Server = 1;
    }
}
