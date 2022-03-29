namespace FamilyAccountRecorder.Common.Model.Structs
{
    /// <summary>
    /// 代表账单基本类型的枚举
    /// </summary>
    public enum BillType : int
    {
        /// <summary> 缺省 </summary>
        Default,
        /// <summary> 收入 </summary>
        Income,
        /// <summary> 支出 </summary>
        Expend,
        /// <summary> 内部转移 </summary>
        MoveOver,

        /// <summary> 特殊账单 </summary>
        Special = 99999999,
    }

    /// <summary>
    /// 代表收入账单子类型的枚举
    /// </summary>
    public enum IncomeBillType : int
    {
        /// <summary> 薪酬收入 </summary>
        Salary,
        /// <summary> 交易收入 </summary>
        Dealer,
        /// <summary> 利息收入 </summary>
        Interests,
        /// <summary> 还入本金 </summary>
        RepaymentIn,
        /// <summary> 转入 </summary>
        MoveIn,
        /// <summary> 借入 </summary>
        BorrowIn,


        /// <summary> 其他收入 </summary>
        Others = 99999999,
    }

    /// <summary>
    /// 代表支出账单子类型的枚举
    /// </summary>
    public enum ExpendBillType : int
    {
        /// <summary> 消费支付 </summary>
        Pay,
        /// <summary> 偿还本金 </summary>
        RepaymentCapital,
        /// <summary> 偿还利息 </summary>
        RepaymentInterests,
        /// <summary> 偿还本息 </summary>
        RepaymentCapitalAndInterests,
        /// <summary> 转出 </summary>
        MoveOut,
        /// <summary> 借出 </summary>
        BorrowOut,

        /// <summary> 其他支出 </summary>
        Others = 99999999,
    }

    /// <summary>
    /// 代表内部转移账单子类型的枚举
    /// </summary>
    public enum MoveOverBillType : int
    {
        /// <summary> 成员间转账 </summary>
        MoveBetweenMembers,
        /// <summary> 自己账户间转账 </summary>
        MoveBetweenSelf,


        /// <summary> 其他转移 </summary>
        Others = 99999999,
    }

    /// <summary>
    /// 代表特殊移账单子类型的枚举
    /// </summary>
    public enum SpecialBillType : int
    {
        /// <summary> 退款到账 </summary>
        PayBackCome,


        /// <summary> 其他特殊账单 </summary>
        Others = 99999999,
    }

    /// <summary>
    /// 代表一条账单记录的数据
    /// </summary>
    [System.Serializable]
    public struct BillData
    {
        public string uid;
        /// <summary> 主体/转出用户 <seealso cref="FamilyMemberData.uid"/> </summary>
        public string srcUser;
        /// <summary> 主体/转出目标账户 <seealso cref="PocketAccountData.uid"/> </summary>
        public string srcAccount;
        /// <summary> 主体/转出经手账户 <seealso cref="PocketAccountData.uid"/> </summary>
        public string srcWayAccount;
        /// <summary> 目标/转入用户 <seealso cref="FamilyMemberData.uid"/> </summary>
        public string dstUser;
        /// <summary> 目标/转入目标账户 <seealso cref="PocketAccountData.uid"/> </summary>
        public string dstAccount;
        /// <summary> 目标/转入经手账户 <seealso cref="PocketAccountData.uid"/> </summary>
        public string dstWayAccount;
        /// <summary> 关联账单 <seealso cref="BillData.uid"/> </summary>
        public string relationBillUid;
        /// <summary> 账单类别 </summary>
        public BillType type;
        /// <summary> 账单子类别 </summary>
        public int subtype;
        /// <summary> 账单金额（分） </summary>
        public long value;
        /// <summary> 账单发生时间 </summary>
        public long dateTime;
        /// <summary> 账单生效金额（分） </summary>
        public long enabledValue;
        /// <summary> 账单生效时间 </summary>
        public long enabledDateTime;
        /// <summary> 账单描述 </summary>
        public string info;
        /// <summary> 账单备注 </summary>
        public string comment;
        /// <summary> 账单标记 <seealso cref="BillTagData.uid"/> </summary>
        public string[] tags;
    }
}
