using FamilyAccountRecorder.Model.Interface;
using FamilyAccountRecorder.ViewInterface;
using FamilyAccountRecorder.ViewInterface.Panels;

using System;

using UnityEngine.UI;

namespace FamilyAccountRecorder.View.Prefab {
    public class DropSelectPanel : AViewPanel, IDropSelectPanel {
        public Dropdown typeList;

        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public event Func<string> OnCommit;

        public DropSelectPanel() : base(IViewPanel.PanelType.DropSelect) { }

        public override void Init(EventArgs_ShowPanel args) {
        }

        public void OnClickOK() {

        }

        public void OnClickCancel() {

        }
    }
}
