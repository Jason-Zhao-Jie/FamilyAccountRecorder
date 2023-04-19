using FamilyAccountRecorder.Data.Factory;
using FamilyAccountRecorder.Data.File;
using FamilyAccountRecorder.Model.Interface;
using FamilyAccountRecorder.Model.Structs;
using FamilyAccountRecorder.Present;

namespace FamilyAccountRecorder
{
    public static class CoreCenter
    {
        public static SystemSettingDropData[] DropList { get => settingFile.SystemSetting.dropList; }
        public static IDropData SelectedDrop { get => DropDataFactory.Create(DropList[settingFile.SystemSetting.selectedDropIndex]); }
        public static string[] FamilyList { get => SelectedDrop.FamilyList; }

        public static void Init()
        {
            settingFile = new SettingFile();
            if (DropList == null || DropList.Length == 0)
            {
                settingFile.InitFile();
            }
            familyManager = new FamilyManager(settingFile.SystemSetting.selectedFamilyName);
        }


        private static SettingFile settingFile;
        private static FamilyManager familyManager;
    }
}