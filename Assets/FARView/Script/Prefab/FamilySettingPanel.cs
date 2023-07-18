using FamilyAccountRecorder.Model.Interface;
using FamilyAccountRecorder.Model.Structs;

namespace FamilyAccountRecorder.View.Prefab
{
	public class FamilySettingPanel : AViewPanel
	{
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

			}
		}

		private bool inited = false;
		private FamilySettingData? initData = null;

    }
}
