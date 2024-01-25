using FamilyAccountRecorder.Model.Interface;
using FamilyAccountRecorder.Model.Structs;
using FamilyAccountRecorder.ViewInterface;
using FamilyAccountRecorder.ViewInterface.Panels;

using System;

using UnityEngine;
using UnityEngine.UI;

namespace FamilyAccountRecorder.View.Prefab {
    public class FamilySettingPanel : AViewPanel, IFamilySettingPanel {
        [SerializeField] private InputField input_familyName;
        [SerializeField] private Dropdown dropdown_familyOwner;
        [SerializeField] private Text text_createTime;
        [SerializeField] private InputField input_startCash;
        [SerializeField] private Text text_startTime;

        public event Action<FamilySettingData> OnCommit;

        private FamilySettingData data;
        public FamilySettingData Data {
            get => data;
            set {
                data = value;
                OnRefreshRevert();
            }
        }

        public FamilySettingPanel() : base(IViewPanel.PanelType.FamilySetting) { }

        // Use this for initialization
        void Awake() {
            OnRefreshRevert();
        }

        public override void Init(EventArgs_ShowPanel args) {
            Data = (args as EventArgs_ShowPanel<FamilySettingData>).Data;
        }

        public void OnClickApply() {
            data.name = input_familyName.text;
            data.owner = dropdown_familyOwner.itemText.text;
            data.initialCash = long.Parse(input_startCash.text);
            data.initialDateTime = long.Parse(text_startTime.text);
        }

        public void OnRefreshRevert() {
            input_familyName.text = data.name;
            dropdown_familyOwner.itemText.text = data.owner;
            text_createTime.text = new DateTime(data.createTime).ToString();
            input_startCash.text = data.initialCash.ToString();
            text_startTime.text = new DateTime(data.initialDateTime).ToString();
            CloseSelf();
            OnCommit(data);
        }

        public void OnChangeStartTime() {
            ProcessMain.EventMgr.NotifySync(new EventArgs_ShowPanelWithResult<DateTime>(IViewPanel.PanelType.DateTimeEdit, IViewPanel.PanelLayer.Popup) { Data = new DateTime(data.initialDateTime), OnCommit = OnStartTimeChange });
        }

        private void OnStartTimeChange(DateTime value) {
            text_startTime.text = value.Ticks.ToString();
        }
    }
}
