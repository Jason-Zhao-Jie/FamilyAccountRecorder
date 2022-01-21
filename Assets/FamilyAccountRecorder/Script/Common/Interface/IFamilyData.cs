using FamilyAccountRecorder.Common.Model.Structs;

namespace FamilyAccountRecorder.Common.Interface
{
    public enum DataSource
    {
        Unknown,
        Memory,
        File,
        DataBase,
        Network,
    }

    public interface IFamilyData
    {
        DataSource DataSource { get; }
        FamilySettingData FamilySetting { get; set; }
        FamilyMemberData GetFamilyMember(string uid);
        string[] GetFamilyMembersByType(AthorityType type);
        string[] GetAllFamilyMembers();
        int SetFamilyMembers(params FamilyMemberData[] members);
        PocketTagData GetPocketTag(string uid);
        string[] GetAllPocketTags();
        int SetPocketTags(params PocketTagData[] tags);
        PocketModalData GetPocketModal(string uid);
        string[] GetAllPocketModals();
        int SetPocketModals(params PocketModalData[] modals);
        PocketAccountData GetPocketAccount(string uid);
        int SetPocketAccounts(params PocketAccountData[] accounts);
        BillTagData GetBillTag(string uid);
        string[] GetAllBillTags();
        int SetBillTags(params BillTagData[] tags);
        BillData GetBill(string uid);
        string[] GetAllBills();
        int SetBills(params BillData[] bills);

    }
}
