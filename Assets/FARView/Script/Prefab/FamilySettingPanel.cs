using UnityEngine;
using UnityEngine.UI;
using FamilyAccountRecorder.Model.Interface;
using FamilyAccountRecorder.Model.Structs;

namespace FamilyAccountRecorder.View.Prefab
{
	public class FamilySettingPanel : AViewPanel
    {
        [SerializeField] private InputField input_familyName;
        [SerializeField] private Dropdown dropdown_familyOwner;
        [SerializeField] private Text text_createTime;
        [SerializeField] private InputField input_startCash;
        [SerializeField] private InputField input_startTime;
        [SerializeField] private Text text_targetAddress;

        // Use this for initialization
        void Start()
		{
			inited = true;
            DoInitShow();
        }

        public override void Init(params object[] data)
        {
			SetHandle((FamilySettingData)data[1]);
        }

        public void SetHandle(FamilySettingData data)
		{
			initData = data;
			DoInitShow();
		}

		public void DoInitShow()
		{
			if(inited && initData != null)
			{
                OnAllRevert();
			}
		}

        public void OnNameRevert()
        {
            input_familyName.text = initData.Value.name;
        }

        public void OnOwnerRevert()
        {
            dropdown_familyOwner.itemText.text = initData.Value.name;
        }

        public void OnStartCashRevert()
        {
            input_startCash.text = initData.Value.initialCash.ToString();
        }

        public void OnStartTimeRevert()
        {
            input_startTime.text = new System.DateTime(initData.Value.initialDateTime).ToString();
        }

        public void OnAllRevert()
        {
            OnNameRevert();
            OnOwnerRevert();
            text_createTime.text = new System.DateTime(initData.Value.createTime).ToString();
            OnStartCashRevert();
            OnStartTimeRevert();
            text_targetAddress.text = "local file";
        }

		private bool inited = false;
		private FamilySettingData? initData = null;

    }
}
