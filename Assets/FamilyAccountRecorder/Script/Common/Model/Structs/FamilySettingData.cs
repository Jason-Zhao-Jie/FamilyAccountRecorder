namespace FamilyAccountRecorder.Common.Model.Structs
{
    /// <summary>
    /// 代表家庭总体设置的一些数据
    /// </summary>
    [System.Serializable]
    public struct FamilySettingData
    {
        /// <summary> 家庭名称 </summary>
        public string name;
        /// <summary> 家庭创建者用户 <seealso cref="FamilyMemberData.uid"/> </summary>
        public string owner;
        /// <summary> 家庭创建时间 </summary>
        public long createTime;
        /// <summary> 家庭初始校正时间 </summary>
        public long initialDateTime;
        /// <summary> 家庭初始现金校正值 </summary>
        public long initialCash;
    }
}
