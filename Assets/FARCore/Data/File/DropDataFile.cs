using ArmyAnt.Manager;
using ArmyAnt.Utility;

using FamilyAccountRecorder.Data.Memory;
using FamilyAccountRecorder.Model.Constants;
using FamilyAccountRecorder.Model.Interface;
using FamilyAccountRecorder.Model.Structs;

namespace FamilyAccountRecorder.Data.File
{
    public class DropDataFile : DropDataMemory
    {
        const string KEY_FILE_NAME = "settings.json";

        public override DataSource DataSource => DataSource.File;

        public DropDataFile(SystemSettingDropData data) : base(data)
        {
            IOManager.MkdirIfNotExist(FileSource.DROP_ROOT);
            Settings = helper.UpdateLoad<DropSettingData>(FileSource.DROP_ROOT, KEY_FILE_NAME);
            if (Settings.familyList == null || Settings.familyList.Length == 0)
            {
                Settings = new DropSettingData { name = data.name, familyList = new string[] { "赵杰的家庭" } };
                helper.UpdateSave(Settings, FileSource.DROP_ROOT, KEY_FILE_NAME);
            }
        }

        public override bool CreateFamily(string name)
        {
            var ret = base.CreateFamily(name);
            if (ret)
            {
                helper.UpdateSave(Settings, FileSource.DROP_ROOT, KEY_FILE_NAME);
            }
            return ret;
        }

        public override bool RemoveFamily(string name)
        {
            var ret = base.RemoveFamily(name);
            if (ret)
            {
                helper.UpdateSave<DropSettingData>(Settings, FileSource.DROP_ROOT, KEY_FILE_NAME);
            }
            return ret;
        }

        private readonly JsonDataDicHelper helper = new JsonDataDicHelper();
    }
}
