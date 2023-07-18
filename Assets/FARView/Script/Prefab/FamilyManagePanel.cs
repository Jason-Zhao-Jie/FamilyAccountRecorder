using FamilyAccountRecorder.Model.Interface;
using FamilyAccountRecorder.Model.Structs;
using FamilyAccountRecorder.View.Constants;

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

        protected void Awake()
        {
            ViewCenter.EventMgr.Listen(Constants.Event.FamilyChanged, OnFamilyCreated);

            dropdown_familySelect.ClearOptions();
            var flist = new List<string>();
            foreach(var i in CoreCenter.FamilyList)
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

        public override void Init(params object[] data)
        {
        }

        public void OnSelectFamily()
        {
            var selected = dropdown_familySelect.itemText.text;
            var data = CoreCenter.SelectFamily(selected);
            text_name.text = data.FamilySetting.name;
            text_owner.text = data.FamilySetting.owner;
            text_createTime.text = new System.DateTime(data.FamilySetting.createTime).ToString();
            text_startCash.text = (data.FamilySetting.initialCash / 100f).ToString();
            text_startTime.text = new System.DateTime(data.FamilySetting.initialDateTime).ToString();
            text_targetAddress.text = "local file";
        }

        public void OnCreateFamily()
        {
            ViewCenter.EventMgr.Notify(Constants.Event.ShowPanel, PanelType.FamilySetting, PanelLayer.Popup, new FamilySettingData());
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
            ViewCenter.EventMgr.Notify(Constants.Event.ShowPanel, PanelType.DropSelect, PanelLayer.Popup);
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

        private void OnFamilyCreated(Constants.Event _event, ulong type, params object[] data)
        {

        }
    }
}