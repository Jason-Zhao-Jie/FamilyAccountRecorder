using FamilyAccountRecorder.Model.Interface;
using FamilyAccountRecorder.Present;
using FamilyAccountRecorder.View.Constants;

using System.Collections.Generic;

using UnityEngine.UI;

namespace FamilyAccountRecorder.View.Prefab
{
    public class FamilyManagePanel : AViewPanel
    {
        public Dropdown dropdown_familySelect;
        public Text text_name;
        public Text text_owner;
        public Text text_createTime;
        public Text text_startCash;
        public Text text_startTime;
        public Text text_targetAddress;

        protected void Awake()
        {
            var drop = Center.SelectedDrop;
            dropdown_familySelect.ClearOptions();
            var flist = new List<string>();
            dropdown_familySelect.AddOptions(flist);
        }

        protected void Start()
        {

        }

        protected void Update()
        {

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
            Center.EventMgr.Notify(Event.ShowPanel, PanelType.DropSelect, PanelLayer.Popup);
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
    }
}