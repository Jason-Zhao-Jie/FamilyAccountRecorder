using ArmyAnt.Manager;

using FamilyAccountRecorder.Common.Interface;
using FamilyAccountRecorder.Common.Model.Structs;
using FamilyAccountRecorder.Common.Present;
using FamilyAccountRecorder.Utility;

namespace FamilyAccountRecorder.Present
{
    public class FamilyDataFile : FamilyDataMemory
    {
        const string KEY_DIR_ROOT = "familyData";
        const string KEY_FAMILY_SETTING = "familySetting";
        const string KEY_FAMILY_MEMBERS = "familyMembers";
        const string KEY_POCKET_TAGS = "pocketTags";
        const string KEY_POCKET_MODALS = "pocketModals";
        const string KEY_POCKET_ACCOUNTS = "pocketAccounts";
        const string KEY_BILL_TAGS = "billTags";
        const string KEY_BILLS = "bills";

        public override DataSource DataSource => DataSource.File;
        public FamilyDataFile(IFamilyManager manager, string name)
        {
            this.manager = manager;
            this.name = name;
            UpdateLoad();
        }

        public void UpdateLoad()
        {
            IOManager.MkdirIfNotExist(KEY_DIR_ROOT);
            IOManager.MkdirIfNotExist(KEY_DIR_ROOT, name);
            // FamilySettingData
            var familySetting = helper.UpdateLoad<FamilySettingData>(KEY_DIR_ROOT, name, KEY_FAMILY_SETTING);
            FamilySetting = familySetting;
            // FamilyMemberData
            var familyMembers = helper.UpdateLoad<FamilyMembersSave>(KEY_DIR_ROOT, name, KEY_FAMILY_MEMBERS);
            if(familyMembers.members != null)
            {
                SetFamilyMembers(familyMembers.members);
            }
            // PocketTagData
            var pocketTags = helper.UpdateLoad<PocketTagsSave>(KEY_DIR_ROOT, name, KEY_POCKET_TAGS);
            if (pocketTags.tags != null)
            {
                SetPocketTags(pocketTags.tags);
            }
            // PocketModalData
            var pocketModals = helper.UpdateLoad<PocketModalsSave>(KEY_DIR_ROOT, name, KEY_POCKET_MODALS);
            if (pocketModals.modals != null)
            {
                SetPocketModals(pocketModals.modals);
            }
            // PocketAccountData
            var pocketAccounts = helper.UpdateLoad<PocketAccountsSave>(KEY_DIR_ROOT, name, KEY_POCKET_ACCOUNTS);
            if (pocketAccounts.accounts != null)
            {
                SetPocketAccounts(pocketAccounts.accounts);
            }
            // BillTagData
            var billTags = helper.UpdateLoad<BillTagsSave>(KEY_DIR_ROOT, name, KEY_BILL_TAGS);
            if (billTags.tags != null)
            {
                SetBillTags(billTags.tags);
            }
            // BillData
            var bills = helper.UpdateLoad<BillsSave>(KEY_DIR_ROOT, name, KEY_BILLS);
            if (bills.bills != null)
            {
                SetBills(bills.bills);
            }
        }
        public void UpdateSave()
        {
            IOManager.MkdirIfNotExist(KEY_DIR_ROOT);
            IOManager.MkdirIfNotExist(KEY_DIR_ROOT, name);
            // FamilySettingData
            helper.UpdateSave(FamilySetting, KEY_DIR_ROOT, name, KEY_FAMILY_SETTING);
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
            helper.UpdateSave(familyMembers, KEY_DIR_ROOT, name, KEY_FAMILY_MEMBERS);
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
            helper.UpdateSave(pocketTags, KEY_DIR_ROOT, name, KEY_POCKET_TAGS);
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
            helper.UpdateSave(pocketModals, KEY_DIR_ROOT, name, KEY_POCKET_MODALS);
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
            helper.UpdateSave(pocketAccounts, KEY_DIR_ROOT, name, KEY_POCKET_ACCOUNTS);
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
            helper.UpdateSave(billTags, KEY_DIR_ROOT, name, KEY_BILL_TAGS);
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
            helper.UpdateSave(bills, KEY_DIR_ROOT, name, KEY_BILLS);
        }

        private string name;
        private IFamilyManager manager;
        private JsonDataDicHelper helper = new JsonDataDicHelper();

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
