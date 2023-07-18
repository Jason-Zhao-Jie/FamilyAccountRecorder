namespace FamilyAccountRecorder.View.Constants
{
    public static class Strings
    {
        public static readonly string NoFamilyText = "<没有家庭>";
    }

    public enum Event : ulong
    {
        ShowPanel,
        ClosePanel,
        FamilyChanged,
    }

    public static class PanelType
    {
        public const ulong DropSelect = 0;
        public const ulong FamilyManager = 1;
        public const ulong FamilySetting = 2;
    }

    public static class PanelLayer
    {
        public const ulong Back = 0;
        public const ulong FullScreen = 1;
        public const ulong Panel = 2;
        public const ulong Popup = 3;
        public const ulong Float = 4;
        public const ulong To = 5;
    }

    public static class DropType
    {
        public const ushort Local = 0;
        public const ushort Server = 1;
    }

    public static class FamilyChangeType
    {
        public const ushort Change = 0;
        public const ushort Create = 1;
        public const ushort Delete = 2;
    }
}
