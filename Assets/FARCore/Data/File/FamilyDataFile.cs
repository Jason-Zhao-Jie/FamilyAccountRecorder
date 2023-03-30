using ArmyAnt.Manager;
using ArmyAnt.Utility;

using FamilyAccountRecorder.Data.Memory;
using FamilyAccountRecorder.Model.Constants;
using FamilyAccountRecorder.Model.Interface;
using FamilyAccountRecorder.Model.Structs;

namespace FamilyAccountRecorder.Data.File
{
    public class FamilyDataFile : FamilyDataMemory
    {
        const string KEY_FAMILY_SETTING = "familySetting.json";
        const string KEY_FAMILY_MEMBERS = "familyMembers.json";
        const string KEY_POCKET_TAGS = "pocketTags.json";
        const string KEY_POCKET_MODALS = "pocketModals.json";
        const string KEY_POCKET_ACCOUNTS = "pocketAccounts.json";
        const string KEY_BILL_TAGS = "billTags.json";
        const string KEY_BILLS = "bills.json";

        public FamilyDataFile(IFamilyManager manager, string name)
        {
            this.manager = manager;
            this.name = name;
            UpdateLoad();
        }

        public void UpdateLoad()
        {
            IOManager.MkdirIfNotExist(FileSource.DROP_ROOT, name);
            // FamilySettingData
            var familySetting = helper.UpdateLoad<FamilySettingData>(FileSource.DROP_ROOT, name, KEY_FAMILY_SETTING);
            FamilySetting = familySetting;
            // FamilyMemberData
            var familyMembers = helper.UpdateLoad<FamilyMembersSave>(FileSource.DROP_ROOT, name, KEY_FAMILY_MEMBERS);
            if(familyMembers.members != null)
            {
                SetFamilyMembers(familyMembers.members);
            }
            // PocketTagData
            var pocketTags = helper.UpdateLoad<PocketTagsSave>(FileSource.DROP_ROOT, name, KEY_POCKET_TAGS);
            if (pocketTags.tags != null)
            {
                SetPocketTags(pocketTags.tags);
            }
            // PocketModalData
            var pocketModals = helper.UpdateLoad<PocketModalsSave>(FileSource.DROP_ROOT, name, KEY_POCKET_MODALS);
            if (pocketModals.modals != null)
            {
                SetPocketModals(pocketModals.modals);
            }
            // PocketAccountData
            var pocketAccounts = helper.UpdateLoad<PocketAccountsSave>(FileSource.DROP_ROOT, name, KEY_POCKET_ACCOUNTS);
            if (pocketAccounts.accounts != null)
            {
                SetPocketAccounts(pocketAccounts.accounts);
            }
            // BillTagData
            var billTags = helper.UpdateLoad<BillTagsSave>(FileSource.DROP_ROOT, name, KEY_BILL_TAGS);
            if (billTags.tags != null)
            {
                SetBillTags(billTags.tags);
            }
            // BillData
            var bills = helper.UpdateLoad<BillsSave>(FileSource.DROP_ROOT, name, KEY_BILLS);
            if (bills.bills != null)
            {
                SetBills(bills.bills);
            }
        }
        public void UpdateSave()
        {
            IOManager.MkdirIfNotExist(FileSource.DROP_ROOT, name);
            // FamilySettingData
            helper.UpdateSave(FamilySetting, FileSource.DROP_ROOT, name, KEY_FAMILY_SETTING);
            // FamilyMemberData
            var familyMemberIds = GetAllFamilyMembers();
            var familyMembers = new FamilyMembersSave
            {
                members = new FamilyMemberData[familyMemberIds.Length]
            };
            for(int i=0;i<familyMemberIds.Length;++i)
            {
                familyMembers.members[i] = GetFamilyMember(familyMemberIds[i]);
            }
            helper.UpdateSave(familyMembers, FileSource.DROP_ROOT, name, KEY_FAMILY_MEMBERS);
            // PocketTagData
            var pocketTagIds = GetAllPocketTags();
            var pocketTags = new PocketTagsSave
            {
                tags = new PocketTagData[pocketTagIds.Length]
            };
            for (int i = 0; i < pocketTagIds.Length; ++i)
            {
                pocketTags.tags[i] = GetPocketTag(pocketTagIds[i]);
            }
            helper.UpdateSave(pocketTags, FileSource.DROP_ROOT, name, KEY_POCKET_TAGS);
            // PocketModalData
            var pocketModalIds = GetAllPocketModals();
            var pocketModals = new PocketModalsSave
            {
                modals = new PocketModalData[pocketModalIds.Length]
            };
            for (int i = 0; i < pocketModalIds.Length; ++i)
            {
                pocketModals.modals[i] = GetPocketModal(pocketModalIds[i]);
            }
            helper.UpdateSave(pocketModals, FileSource.DROP_ROOT, name, KEY_POCKET_MODALS);
            // PocketAccountData
            var pocketAccountIds = GetAllPocketAccounts();
            var pocketAccounts = new PocketAccountsSave
            {
                accounts = new PocketAccountData[pocketAccountIds.Length]
            };
            for (int i = 0; i < pocketAccountIds.Length; ++i)
            {
                pocketAccounts.accounts[i] = GetPocketAccount(pocketAccountIds[i]);
            }
            helper.UpdateSave(pocketAccounts, FileSource.DROP_ROOT, name, KEY_POCKET_ACCOUNTS);
            // BillTagData
            var billTagIds = GetAllBillTags();
            var billTags = new BillTagsSave
            {
                tags = new BillTagData[billTagIds.Length]
            };
            for (int i = 0; i < billTagIds.Length; ++i)
            {
                billTags.tags[i] = GetBillTag(billTagIds[i]);
            }
            helper.UpdateSave(billTags, FileSource.DROP_ROOT, name, KEY_BILL_TAGS);
            // BillData
            var billIds = GetAllBills();
            var bills = new BillsSave
            {
                bills = new BillData[billIds.Length]
            };
            for (int i = 0; i < billIds.Length; ++i)
            {
                bills.bills[i] = GetBill(billIds[i]);
            }
            helper.UpdateSave(bills, FileSource.DROP_ROOT, name, KEY_BILLS);
        }

        private readonly string name;
        private IFamilyManager manager;
        private readonly JsonDataDicHelper helper = new JsonDataDicHelper();

        [System.Serializable]
        private class FamilyMembersSave
        {
            public FamilyMemberData[] members;
        }

        [System.Serializable]
        private class PocketTagsSave
        {
            public PocketTagData[] tags;
        }

        [System.Serializable]
        private class PocketModalsSave
        {
            public PocketModalData[] modals;
        }

        [System.Serializable]
        private class PocketAccountsSave
        {
            public PocketAccountData[] accounts;
        }

        [System.Serializable]
        private class BillTagsSave
        {
            public BillTagData[] tags;
        }

        [System.Serializable]
        private class BillsSave
        {
            public BillData[] bills;
        }
    }
}
