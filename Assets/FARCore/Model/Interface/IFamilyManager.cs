using FamilyAccountRecorder.Model.Structs;

namespace FamilyAccountRecorder.Model.Interface
{
    /// <summary>
    /// 代表家庭账户的管理接口
    /// </summary>
    public interface IFamilyManager
    {
        FamilySettingData FamilySetting { get; }
        string FamilyName { get; set; }
        string FamilyOwner { get; set; }
        long FamilyInitialDateTime { get; set; }
        long FamilyInitialCash { get; set; }
        IFamilyData Data { get; }
        IFamilyDataCalculator Calculator { get; }
    }
}
