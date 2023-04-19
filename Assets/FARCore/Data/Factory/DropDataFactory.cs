using FamilyAccountRecorder.Data.File;
using FamilyAccountRecorder.Data.Memory;
using FamilyAccountRecorder.Model.Interface;
using FamilyAccountRecorder.Model.Structs;

namespace FamilyAccountRecorder.Data.Factory
{
    public class DropDataFactory
    {
        public static IDropData Create(SystemSettingDropData dropData)
        {
            switch ((DataSource)dropData.dataType)
            {
                case DataSource.Memory:
                    return new DropDataMemory(dropData);
                case DataSource.File:
                    return new DropDataFile(dropData);
                case DataSource.DataBase:
                case DataSource.Network:
                case DataSource.Unknown:
                default:
                    return null;
            }

        }
    }
}