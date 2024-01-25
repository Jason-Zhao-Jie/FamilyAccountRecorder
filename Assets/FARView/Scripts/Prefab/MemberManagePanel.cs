using FamilyAccountRecorder.Model.Interface;
using FamilyAccountRecorder.ViewInterface;
using FamilyAccountRecorder.ViewInterface.Panels;

namespace FamilyAccountRecorder.View.Prefab {
    public class MemberManagePanel : AViewPanel, IMemberManagePanel {
        private string family;
        public string Family {
            get => family;
            set {
                family = value;
            }
        }

        public MemberManagePanel() : base(IViewPanel.PanelType.MemberManage) { }

        public override void Init(EventArgs_ShowPanel args) {
        }
    }
}
