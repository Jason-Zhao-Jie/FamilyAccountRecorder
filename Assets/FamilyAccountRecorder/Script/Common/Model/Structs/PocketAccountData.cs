namespace FamilyAccountRecorder.Common.Model.Structs
{
    /// <summary>
    /// 代表某个用户的某个账户信息的数据
    /// </summary>
    [System.Serializable]
    public struct PocketAccountData
    {
        public string uid;
        /// <summary> 模型 uid <seealso cref="PocketModalData.uid"/> </summary>
        public string modal;
        /// <summary> 账户所有者 <seealso cref="FamilyMemberData.uid"/> </summary>
        public string user;
        /// <summary> 账户登录名 </summary>
        public string accountLoginId;
        /// <summary> 账户 uid，如没有则同登录名 </summary>
        public string accountUserId;
        /// <summary> 账户初始资金（分） </summary>
        public long accountInitialValue;
        /// <summary> 账户登陆密码，用于保存登录密码 </summary>
        public long accountLoginPwd;
    }
}
