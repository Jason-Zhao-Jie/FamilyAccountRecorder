namespace FamilyAccountRecorder.Common.Model
{
    public enum BillType : int
    {
        /// <summary> 缺省 </summary>
        Default,
        /// <summary> 收入 </summary>
        Income,
        /// <summary> 支出 </summary>
        Expend,
        /// <summary> 转移 </summary>
        MoveOver,
    }

    public enum IncomeBillType
    {
        /// <summary> 薪酬收入 </summary>
        Salary,
        /// <summary> 交易收入 </summary>
        Dealer,
        /// <summary> 利息收入 </summary>
        Interests,
        /// <summary> 转入 </summary>
        MoveIn,
        /// <summary> 贷款到账 </summary>
        Borrow,


        /// <summary> 其他收入 </summary>
        Others = 99,
    }

    public enum ExpendBillType
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

        /// <summary> 其他支出 </summary>
        Others = 99,
    }

    public enum MoveOverBillType
    {
        /// <summary> 成员间转账 </summary>
        MoveBetweenMembers,
        /// <summary> 自己账户间转账 </summary>
        MoveBetweenSelf,


        /// <summary> 其他转移 </summary>
        Others = 99,
    }

    public struct BillData
    {
        public string uid;
    }
}
