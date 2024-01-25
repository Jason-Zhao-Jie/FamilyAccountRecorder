using FamilyAccountRecorder.Model.Interface;
using FamilyAccountRecorder.ViewInterface;
using FamilyAccountRecorder.ViewInterface.Panels;

namespace FamilyAccountRecorder.View.Prefab
{
    public class TagManagePanel : AViewPanel, ITagManagePanel
    {
        public TagManagePanel() : base(IViewPanel.PanelType.TagManage) { }

        private string family;
        public string Family {
            get => family;
            set {
                family = value;
            }
        }

        public override void Init(EventArgs_ShowPanel args)
        {
        }
    }
}