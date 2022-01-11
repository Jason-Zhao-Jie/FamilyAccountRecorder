namespace FamilyAccountRecorder.Common.Model
{
    /// <summary>
    /// 表示用户权限的枚举
    /// </summary>
    public enum AthorityType : int
    {
        /// <summary> 创建人 </summary>
        Originator,
        /// <summary> 管理员 </summary>
        Administrator,
        /// <summary> 普通用户 </summary>
        User,
        /// <summary> 只读访客 </summary>
        Guest,
    }

    /// <summary>
    /// 表示用户性别的枚举
    /// </summary>
    public enum Gender : int
    {
        /// <summary> 未知性别 </summary>
        Unknown,
        /// <summary> 男性 </summary>
        Male,
        /// <summary> 女性 </summary>
        Female,
        /// <summary> 其他性别 </summary>
        Others,
    }

    /// <summary>
    /// 表示用户的基本数据
    /// </summary>
    public struct FamilyMemberData
    {
        public string uid;
        /// <summary> 用户权限 </summary>
        public AthorityType athority;
        /// <summary> 用户姓名，可更改 </summary>
        public string name;
        /// <summary> 用户性别，可更改 </summary>
        public Gender gender;
        /// <summary> 用户签名，可更改 </summary>
        public string signWords;
        /// <summary> 用户资金账户 <seealso cref="PocketAccountData.uid"/> </summary>
        public string[] accounts;
    }

}