using FamilyAccountRecorder.Model.Interface;
using FamilyAccountRecorder.Model.Structs;

using System.Collections.Generic;
using System.Linq;

namespace FamilyAccountRecorder.Data.Memory
{
    public class DropDataMemory : IDropData
    {
        public DropDataMemory(SystemSettingDropData data)
        {
            DropData = data;
        }

        public virtual SystemSettingDropData DropData { get; private set; }
        public virtual DataSource DataSource => DataSource.Memory;

        public string Address { get; protected set; } = "";

        public string Name
        {
            get => Settings.name;
        }

        public string[] FamilyList
        {
            get => Settings.familyList;
        }

        public virtual bool CreateFamily(string name)
        {
            var ret = FamilyList.Contains(name);
            if (!ret)
            {
                var newList = new List<string>(Settings.familyList)
                {
                    name
                };
                Settings.familyList = newList.ToArray();
            }
            return !ret;
        }

        public virtual bool RemoveFamily(string name)
        {
            var newList = new List<string>(Settings.familyList);
            var ret = newList.Remove(name);
            Settings.familyList = newList.ToArray();
            return ret;
        }

        protected DropSettingData Settings;
    }
}
