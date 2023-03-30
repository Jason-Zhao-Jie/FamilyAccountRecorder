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
        string Address { get; }
        string Name { get; }
        string[] FamilyList { get; }
        bool CreateFamily(string name);
    }
}
