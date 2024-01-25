using FamilyAccountRecorder.Model.Interface;
using FamilyAccountRecorder.View.Constants;
using FamilyAccountRecorder.ViewInterface;
using FamilyAccountRecorder.ViewInterface.Panels;

using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace FamilyAccountRecorder.View.Prefab {
    public class FamilySelectPanel : AViewPanel, IFamilySelectPanel {
        [SerializeField] private Dropdown dropdown_familySelect;
        [SerializeField] private Text text_name;
        [SerializeField] private Text text_owner;
        [SerializeField] private Text text_createTime;
        [SerializeField] private Text text_startCash;
        [SerializeField] private Text text_startTime;
        [SerializeField] private Text text_targetAddress;

        [SerializeField] private Button[] noFamilyForbidButtons;

        private bool inited = false;
        private string selectedName;
        public string Name {
            get => selectedName;
            set {
                selectedName = value;
                if (inited) {
                    for (int i = 0; i < dropdown_familySelect.options.Count; ++i) {
                        if (dropdown_familySelect.options[i].text == selectedName) {
                            dropdown_familySelect.value = i;
                            break;
                        }
                    }
                }
            }
        }

        public event Action<string> OnCommit;

        public FamilySelectPanel() : base(IViewPanel.PanelType.FamilySetting) { }

        protected void Awake() {
            RefreshList();
            inited = true;
            Name = name;
            ProcessMain.EventMgr.Listen(ViewInterface.Event.FamilyChanged, OnFamilyCreated);
        }

        public override void Init(EventArgs_ShowPanel args) {
            if (args is EventArgs_ShowPanelWithResult<string> callbackArgs) {
                Name = callbackArgs.Data;
                OnCommit += callbackArgs.OnCommit;
            } else if (args is EventArgs_ShowPanel<string> dataArgs) {
                Name = dataArgs.Data;
            }
        }

        public void OnSelectFamily() {
            var selected = dropdown_familySelect.itemText.text;
            if (string.IsNullOrEmpty(selected) || selected == Strings.NoFamilyText) {
                string none = "-";
                text_name.text = none;
                text_owner.text = none;
                text_createTime.text = none;
                text_startCash.text = "0";
                text_startTime.text = none;
                text_targetAddress.text = "local file";
                foreach (var b in noFamilyForbidButtons) {
                    b.interactable = false;
                }
            } else {
                var data = ProcessMain.SelectFamily(selected);
                text_name.text = data.FamilySetting.name;
                text_owner.text = data.FamilySetting.owner;
                text_createTime.text = new DateTime(data.FamilySetting.createTime).ToString();
                text_startCash.text = (data.FamilySetting.initialCash / 100f).ToString();
                text_startTime.text = new DateTime(data.FamilySetting.initialDateTime).ToString();
                text_targetAddress.text = "local file";
                foreach (var b in noFamilyForbidButtons) {
                    b.interactable = true;
                }
            }
        }

        public void OnClickSelect() {
            CloseSelf();
            Name = text_name.text;
            OnCommit(Name);
        }

        public void OnClickManage() {
            ProcessMain.EventMgr.NotifySync(new EventArgs_ShowPanel<string>(IViewPanel.PanelType.FamilySelect, IViewPanel.PanelLayer.Popup));
        }

        public void OnClickCreate() {
            ProcessMain.SelectFamily("<New Family>");
        }

        private void OnFamilyCreated(IEventManager.IEventArgs arg) {
            if(arg is EventArgs_CreateFamily dataArg) {
                RefreshList();
                Name = dataArg.Data.name;
            }
        }

        private void RefreshList() {
            dropdown_familySelect.ClearOptions();
            var flist = new List<string>();
            foreach (var i in ProcessMain.FamilyList) {
                flist.Add(i);
            }
            dropdown_familySelect.AddOptions(flist);
        }
    }
}