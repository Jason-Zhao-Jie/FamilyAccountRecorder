namespace FamilyAccountRecorder.ViewInterface{
    public interface IViewPanel {
        public enum PanelType {
            Dialog,
            DateTimeEdit,
            SystemSetting,
            DropSelect,
            FamilySelect,
            FamilyManage,
            FamilySetting,
            MemberManage,
            TagManage,
            BillListMain,
        }

        public enum PanelLayer {
            Back,
            FullScreen,
            Panel,
            Popup,
            Float,
            To,
        }

        PanelType Type { get; }
        void Open(PanelLayer layerIndex, object layerRoot);
        void Close();
    }
}
