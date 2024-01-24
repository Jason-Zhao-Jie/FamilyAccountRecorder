using System.Collections.Generic;

using FamilyAccountRecorder.Model.Structs;

namespace FamilyAccountRecorder.Model.Utility
{
    public class FamilyMemberDataDic : DataDic<string, FamilyMemberData>
    {
        public override FamilyMemberData Get(string key)
        {
            if (ContainsKey(key))
            {
                return this[key];
            }
            else
            {
                return default;
            }
        }

        public string[] GetByType(AthorityType type)
        {
            switch (type)
            {
                case AthorityType.Administrator:
                    return administrators.ToArray();
                case AthorityType.User:
                    return users.ToArray();
                case AthorityType.Guest:
                    return guests.ToArray();
                default:
                    var ret = new List<string>();
                    foreach (var m in this)
                    {
                        if (m.Value.athority == type)
                        {
                            ret.Add(m.Key);
                        }
                    }
                    return ret.ToArray();
            }
        }

        public override void Set(string key, FamilyMemberData value)
        {
            if (ContainsKey(key))
            {
                var old = this[key];
                switch (old.athority)
                {
                    case AthorityType.Administrator:
                        if (!administrators.Contains(key))
                        {
                            throw new System.ApplicationException();
                        }
                        administrators.Remove(key);
                        break;
                    case AthorityType.User:
                        if (!users.Contains(key))
                        {
                            throw new System.ApplicationException();
                        }
                        users.Remove(key);
                        break;
                    case AthorityType.Guest:
                        if (!guests.Contains(key))
                        {
                            throw new System.ApplicationException();
                        }
                        guests.Remove(key);
                        break;
                }
                Remove(key);
            }
            Add(key, value);
            switch (value.athority)
            {
                case AthorityType.Administrator:
                    if (administrators.Contains(key))
                    {
                        throw new System.ApplicationException();
                    }
                    administrators.Add(key);
                    break;
                case AthorityType.User:
                    if (users.Contains(key))
                    {
                        throw new System.ApplicationException();
                    }
                    users.Add(key);
                    break;
                case AthorityType.Guest:
                    if (guests.Contains(key))
                    {
                        throw new System.ApplicationException();
                    }
                    guests.Add(key);
                    break;
            }
        }

        public void Set(FamilyMemberData value)
        {
            Set(value.uid, value);
        }

        public int SetFamilyMembers(params FamilyMemberData[] members)
        {
            int ret = 0;
            if (members != null)
            {
                foreach (var m in members)
                {
                    Set(m);
                    ++ret;
                }
            }
            return ret;
        }

        private readonly List<string> administrators = new List<string>();
        private readonly List<string> users = new List<string>();
        private readonly List<string> guests = new List<string>();
    }
}
