using FamilyAccountRecorder.Data.File;
using FamilyAccountRecorder.Model.Structs;
using FamilyAccountRecorder.View;
using FamilyAccountRecorder.View.Constants;

using UnityEngine.SocialPlatforms;

namespace FamilyAccountRecorder
{
    public static class Center
    {
        public static EventManager EventMgr { get; set; }
        public static SystemSettingDropData[] DropList { get => settingFile.SystemSetting.dropList; }
        public static SystemSettingDropData SelectedDrop { get => DropList[settingFile.SystemSetting.selectedDropIndex]; }

        public static void Init()
        {
            settingFile = new SettingFile();
            if (DropList == null || DropList.Length == 0)
            {
                settingFile.InitFile();
            }
            EventMgr.Notify(Event.ShowPanel, PanelType.FamilyManager, PanelLayer.Panel);
        }

        private static SettingFile settingFile;
    }
}
