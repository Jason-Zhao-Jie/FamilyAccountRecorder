using FamilyAccountRecorder.Common.Interface;
using FamilyAccountRecorder.Common.Model.Structs;
using FamilyAccountRecorder.Common.Utility;

namespace FamilyAccountRecorder.Common.Present
{
    /// <summary>
    /// 代表家庭账户全部数据的内存模型
    /// </summary>
    public class FamilyDataMemory : IFamilyData
    {
        public virtual DataSource DataSource => DataSource.Memory;
        public FamilySettingData FamilySetting
        {
            get
            {
                return familySetting;
            }
            set
            {
                familySetting = value;
            }
        }

        public FamilyMemberData GetFamilyMember(string uid)
        {
            return familyMembers.Get(uid);
        }

        public string[] GetFamilyMembersByType(AthorityType type)
        {
            return familyMembers.GetByType(type);
        }

        public string[] GetAllFamilyMembers()
        {
            return familyMembers.GetAll();
        }

        public int SetFamilyMembers(params FamilyMemberData[] members)
        {
            return familyMembers.SetFamilyMembers(members);
        }

        public PocketTagData GetPocketTag(string uid)
        {
            return pocketTags.Get(uid);
        }

        public string[] GetAllPocketTags()
        {
            return pocketTags.GetAll();
        }

        public int SetPocketTags(params PocketTagData[] tags)
        {
            int ret = 0;
            if (tags != null)
            {
                foreach (var t in tags)
                {
                    pocketTags.Set(t.uid, t);
                    ++ret;
                }
            }
            return ret;
        }

        public PocketModalData GetPocketModal(string uid)
        {
            return pocketModals.Get(uid);
        }

        public string[] GetAllPocketModals()
        {
            return pocketModals.GetAll();
        }

        public int SetPocketModals(params PocketModalData[] modals)
        {
            int ret = 0;
            if (modals != null)
            {
                foreach (var m in modals)
                {
                    pocketModals.Set(m.uid, m);
                    ++ret;
                }
            }
            return ret;
        }

        public PocketAccountData GetPocketAccount(string uid)
        {
            return pocketAccounts.Get(uid);
        }

        public string[] GetAllPocketAccounts()
        {
            return pocketAccounts.GetAll();
        }

        public int SetPocketAccounts(params PocketAccountData[] accounts)
        {
            int ret = 0;
            if (accounts != null)
            {
                foreach (var a in accounts)
                {
                    pocketAccounts.Set(a.uid, a);
                    ++ret;
                }
            }
            return ret;
        }

        public BillTagData GetBillTag(string uid)
        {
            return billTags.Get(uid);
        }

        public string[] GetAllBillTags()
        {
            return billTags.GetAll();
        }

        public int SetBillTags(params BillTagData[] tags)
        {
            int ret = 0;
            if (tags != null)
            {
                foreach (var t in tags)
                {
                    billTags.Set(t.uid, t);
                    ++ret;
                }
            }
            return ret;
        }

        public BillData GetBill(string uid)
        {
            return bills.Get(uid);
        }

        public string[] GetAllBills()
        {
            return bills.GetAll();
        }

        public int SetBills(params BillData[] bills)
        {
            int ret = 0;
            if (bills != null)
            {
                foreach (var b in bills)
                {
                    this.bills.Set(b.uid, b);
                    ++ret;
                }
            }
            return ret;
        }

        private FamilySettingData familySetting;

        private readonly FamilyMemberDataDic familyMembers = new FamilyMemberDataDic();
        private readonly DataDic<string, PocketTagData> pocketTags = new DataDic<string, PocketTagData>();
        private readonly DataDic<string, PocketModalData> pocketModals = new DataDic<string, PocketModalData>();
        private readonly DataDic<string, PocketAccountData> pocketAccounts = new DataDic<string, PocketAccountData>();
        private readonly DataDic<string, BillTagData> billTags = new DataDic<string, BillTagData>();
        private readonly DataDic<string, BillData> bills = new DataDic<string, BillData>();
    }
}
