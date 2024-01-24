using FamilyAccountRecorder.Model.Interface;
using FamilyAccountRecorder.ViewInterface;
using FamilyAccountRecorder.ViewInterface.Panels;

using System;
using System.Collections.Generic;

using UnityEngine.UI;

namespace FamilyAccountRecorder.View.Prefab {
    public class DropSelectPanel : AViewPanel, IDropSelectPanel {
        public Dropdown typeList;

        private bool inited = false;
        private string selectedName;
        public string Name { 
            get => selectedName; 
            set {
                selectedName = value;
                if(inited) {
                    for (int i = 0; i < typeList.options.Count; ++i) {
                        if (typeList.options[i].text == selectedName) {
                            typeList.value = i;
                            break;
                        }
                    }
                }
            }
        }
        public event Action<string> OnCommit;

        public DropSelectPanel() : base(IViewPanel.PanelType.DropSelect) { }

        public override void Init(EventArgs_ShowPanel args) {
            if (args is EventArgs_ShowPanelWithResult<string> commitArgs) {
                Name = commitArgs.Data;
                OnCommit = commitArgs.OnCommit;
            } else if (args is EventArgs_ShowPanel<string> dataArgs) {
                Name = dataArgs.Data;
            } else {
                Name = ProcessMain.SelectedDrop.Name;
            }
        }

        public void OnClickOK() {
            ProcessMain.EventMgr.NotifySync(new EventArgs_ClosePanel(Type));
            OnCommit(Name);
        }

        public void OnClickCancel() {
            ProcessMain.EventMgr.NotifySync(new EventArgs_ClosePanel(Type));
        }

        private void Awake() {
            typeList.ClearOptions();
            var options = new List<string>();
            foreach(var i in ProcessMain.DropList) {
                options.Add(i.name);
            }
            typeList.AddOptions(options);
            inited = true;
            Name = selectedName;
        }
    }
}
