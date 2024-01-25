using FamilyAccountRecorder.Model.Interface;
using FamilyAccountRecorder.ViewInterface;
using FamilyAccountRecorder.ViewInterface.Panels;

namespace FamilyAccountRecorder.View.Prefab {
    public class BillListMainPanel : AViewPanel, IBillListMainPanel {
        private string family;
        public string Family {
            get => family;
            set {
                family = value;
            }
        }
        public BillListMainPanel() : base(IViewPanel.PanelType.BillListMain) { }

        public override void Init(EventArgs_ShowPanel args) {

        }
    }
}
