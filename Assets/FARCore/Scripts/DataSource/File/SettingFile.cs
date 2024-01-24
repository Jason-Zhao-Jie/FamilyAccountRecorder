using ArmyAnt.Utility;

using FamilyAccountRecorder.Model.Structs;

using System;

namespace FamilyAccountRecorder.DataSource.File
{
    public class SettingFile
    {
        const string KEY_FILE_NAME = "settings.json";
        public SystemSettingData SystemSetting
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        public SettingFile()
        {
            UpdateLoad();
        }

        public void InitFile()
        {
            data = new SystemSettingData
            {
                dropList = new SystemSettingDropData[]{
                    new SystemSettingDropData() {
                        name="本地数据",
                        address="",
                        dataType=Convert.ToUInt16(Model.Interface.DataSource.File)
                    },
                    new SystemSettingDropData() {
                        name="本地服务器",
                        address="127.0.0.1:3674",
                        dataType=Convert.ToUInt16(Model.Interface.DataSource.Network)
                    },
                    new SystemSettingDropData() {
                        name="网络服务器",
                        address="192.168.0.1:3674",
                        dataType=Convert.ToUInt16(Model.Interface.DataSource.Network)
                    },
                },
                selectedDropIndex = 0,
                selectedFamilyName = "赵杰的家庭"
            };
            UpdateSave();
        }

        public void UpdateLoad()
        {
            data = helper.UpdateLoad<SystemSettingData>(KEY_FILE_NAME);
        }

        public void UpdateSave()
        {
            helper.UpdateSave(data, KEY_FILE_NAME);
        }

        public void SelectFamily(string name)
        {
            data.selectedFamilyName = name;
        }

        private SystemSettingData data;
        private readonly JsonDataDicHelper helper = new JsonDataDicHelper();
    }
}
