using FamilyAccountRecorder.DataSource.File;
using FamilyAccountRecorder.DataSource.Memory;
using FamilyAccountRecorder.Model.Interface;
using FamilyAccountRecorder.Model.Structs;

namespace FamilyAccountRecorder.DataSource.Factory
{
    public class DropDataFactory
    {
        public static IDropData Create(SystemSettingDropData dropData)
        {
            switch ((Model.Interface.DataSource)dropData.dataType)
            {
                case Model.Interface.DataSource.Memory:
                    return new DropDataMemory(dropData);
                case Model.Interface.DataSource.File:
                    return new DropDataFile(dropData);
                case Model.Interface.DataSource.DataBase:
                case Model.Interface.DataSource.Network:
                case Model.Interface.DataSource.Unknown:
                default:
                    return null;
            }

        }
    }
}