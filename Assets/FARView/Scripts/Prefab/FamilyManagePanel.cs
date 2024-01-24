using FamilyAccountRecorder.Model.Interface;
using FamilyAccountRecorder.Model.Structs;
using FamilyAccountRecorder.View.Constants;
using FamilyAccountRecorder.ViewInterface;

using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

namespace FamilyAccountRecorder.View.Prefab
{
    public class FamilyManagePanel : AViewPanel
    {
        [SerializeField] private Dropdown dropdown_familySelect;
        [SerializeField] private Text text_name;
        [SerializeField] private Text text_owner;
        [SerializeField] private Text text_createTime;
        [SerializeField] private Text text_startCash;
        [SerializeField] private Text text_startTime;
        [SerializeField] private Text text_targetAddress;

        [SerializeField] private Button[] noFamilyForbidButtons;

        public FamilyManagePanel() : base(IViewPanel.PanelType.FamilyManage) { }

        protected void Awake()
        {
            ProcessMain.EventMgr.Listen(ViewInterface.Event.FamilyChanged, OnFamilyCreated);

            dropdown_familySelect.ClearOptions();
            var flist = new List<string>();
            foreach(var i in ProcessMain.FamilyList)
            {
                flist.Add(i);
            }
            dropdown_familySelect.AddOptions(flist);
        }

        protected void Start()
        {
            OnSelectFamily();
        }

        protected void Update()
        {

        }

        public override void Init(EventArgs_ShowPanel args)
        {
        }

        public void OnSelectFamily()
        {
            var selected = dropdown_familySelect.itemText.text;
            if (string.IsNullOrEmpty(selected) || selected == Strings.NoFamilyText)
            {
                string none = "-";
                text_name.text = none;
                text_owner.text = none;
                text_createTime.text = none;
                text_startCash.text = "0";
                text_startTime.text = none;
                text_targetAddress.text = "local file";
                foreach(var b in noFamilyForbidButtons)
                {
                    b.interactable = false;
                }
            }
            else
            {
                var data = ProcessMain.SelectFamily(selected);
                text_name.text = data.FamilySetting.name;
                text_owner.text = data.FamilySetting.owner;
                text_createTime.text = new System.DateTime(data.FamilySetting.createTime).ToString();
                text_startCash.text = (data.FamilySetting.initialCash / 100f).ToString();
                text_startTime.text = new System.DateTime(data.FamilySetting.initialDateTime).ToString();
                text_targetAddress.text = "local file";
                foreach (var b in noFamilyForbidButtons)
                {
                    b.interactable = true;
                }
            }
        }

        public void OnCreateFamily()
        {
            var args = new EventArgs_ShowPanel<FamilySettingData>(IViewPanel.PanelType.FamilySetting, IViewPanel.PanelLayer.Popup);
            args.Data = new FamilySettingData();
            ProcessMain.EventMgr.NotifySync(args);
        }

        public void OnClickRename()
        {

        }

        public void OnClickEditStartCash()
        {

        }

        public void OnClickEditStartTime()
        {

        }

        public void OnClickChangeTarget()
        {
            ProcessMain.EventMgr.NotifySync(new EventArgs_ShowPanel(IViewPanel.PanelType.DropSelect, IViewPanel.PanelLayer.Popup));
        }

        public void OnClickSwitchTo()
        {

        }

        public void OnClickDelete()
        {

        }

        public void OnClickCreate()
        {

        }

        private void OnFamilyCreated(IEventManager.IEventArgs arg)
        {

        }
    }
}