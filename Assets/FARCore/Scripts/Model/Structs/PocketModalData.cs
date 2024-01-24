namespace FamilyAccountRecorder.Model.Structs
{
    /// <summary>
    /// 代表资金出入源类型的枚举
    /// </summary>
    public enum PocketType : int
    {
        /// <summary> 未知 </summary>
        Unknown,
        /// <summary> 现金方式 </summary>
        Cash,
        /// <summary> 银行借记卡 </summary>
        Bank_Debit,
        /// <summary> 银行信用卡 </summary>
        Bank_Cridit,
        /// <summary> 网络钱包账户 </summary>
        NetworkPocket,
        /// <summary> 网络信贷账户 </summary>
        P2PLoan,
        /// <summary> 投资账户 </summary>
        InvestmentAccount,
    }

    /// <summary>
    /// 代表资金出入源基础的数据
    /// </summary>
    [System.Serializable]
    public struct PocketModalData
    {
        public string uid;
        /// <summary> 源类别 </summary>
        public PocketType type;
        /// <summary> 名称 </summary>
        public string name;
        /// <summary> 组织 </summary>
        public string organization;
        /// <summary> 标签 <seealso cref="PocketTagData.uid"/> </summary>
        public string[] tags;
        /// <summary> 能否充值 </summary>
        public bool canChargeIn;
        /// <summary> 能否支付 </summary>
        public bool canPayOut;
        /// <summary> 能否转入 </summary>
        public bool canMoveIn;
        /// <summary> 能否转出 </summary>
        public bool canMoveOut;
        /// <summary> 能否借贷 </summary>
        public bool canBorrow;
    }
}
