using FamilyAccountRecorder.Model.Structs;

namespace FamilyAccountRecorder.Model.Interface
{
    public enum DataSource : ushort
    {
        Unknown,
        Memory,
        File,
        DataBase,
        Network,
    }

    public interface IDropData
    {
        DataSource DataSource { get; }
        SystemSettingDropData DropData { get; }
        string Address { get; }
        string Name { get; }
        string[] FamilyList { get; }
        bool CreateFamily(string name);
        bool RemoveFamily(string name);
    }
}
