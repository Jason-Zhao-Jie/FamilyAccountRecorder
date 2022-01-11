namespace FamilyAccountRecorder.Common.Model.Structs
{
    /// <summary>
    /// 账单标记数据
    /// </summary>
    [System.Serializable]
    public struct BillTagData
    {
        public string uid;
        /// <summary> 标记名称 </summary>
        public string name;
        /// <summary> 标记备注 </summary>
        public string comment;
    }
}
