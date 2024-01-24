using FamilyAccountRecorder.Model.Interface;
using FamilyAccountRecorder.ViewInterface;
using FamilyAccountRecorder.ViewInterface.Panels;

namespace FamilyAccountRecorder.View.Prefab {
    public class SystemSettingPanel : AViewPanel, ISystemSettingPanel {
        public SystemSettingPanel() : base(IViewPanel.PanelType.SystemSetting) { }

        public override void Init(EventArgs_ShowPanel args) {
        }
    }
}
