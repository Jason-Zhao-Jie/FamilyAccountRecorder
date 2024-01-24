using FamilyAccountRecorder.DataSource.File;
using FamilyAccountRecorder.Model.Interface;
using FamilyAccountRecorder.Model.Structs;

namespace FamilyAccountRecorder.Present
{
    public class FamilyManager : IFamilyManager
    {
        public FamilySettingData FamilySetting => Data.FamilySetting;
        public string FamilyName
        {
            get
            {
                return Data.FamilySetting.name;
            }
            set
            {
                var ret = Data.FamilySetting;
                ret.name = value;
                Data.FamilySetting = ret;
            }
        }
        public string FamilyOwner
        {
            get
            {
                return Data.FamilySetting.owner;
            }
            set
            {
                var ret = Data.FamilySetting;
                ret.owner = value;
                Data.FamilySetting = ret;
            }
        }
        public long FamilyInitialDateTime
        {
            get
            {
                return Data.FamilySetting.initialDateTime;
            }
            set
            {
                var ret = Data.FamilySetting;
                ret.initialDateTime = value;
                Data.FamilySetting = ret;
            }
        }
        public long FamilyInitialCash
        {
            get
            {
                return Data.FamilySetting.initialCash;
            }
            set
            {
                var ret = Data.FamilySetting;
                ret.initialCash = value;
                Data.FamilySetting = ret;
            }
        }

        public IFamilyData Data => data;

        public IFamilyDataCalculator Calculator => calculator;

        public FamilyManager(string name)
        {
            var fdata = new FamilyDataFile(this, name);
            data = fdata;
            calculator = null;
        }

        private IFamilyData data = null;
        private IFamilyDataCalculator calculator = null;
    }

}
