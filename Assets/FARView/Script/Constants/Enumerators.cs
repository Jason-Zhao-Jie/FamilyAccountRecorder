namespace FamilyAccountRecorder.View.Constants
{
    public enum Event : ulong
    {
        ShowPanel,
        ClosePanel,
        FamilyChanged,
    }

    public static class PanelType
    {
        public static ulong DropSelect = 0;
        public static ulong FamilyManager = 1;
        public static ulong FamilySetting = 2;
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

    public static class FamilyChangeType
    {
        public static ushort Change = 0;
        public static ushort Create = 1;
        public static ushort Delete = 2;
    }
}
