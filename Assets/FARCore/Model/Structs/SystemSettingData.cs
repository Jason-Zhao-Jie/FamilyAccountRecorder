namespace FamilyAccountRecorder.Model.Structs
{
    /// <summary>
    /// 系统设置存储数据
    /// </summary>
    [System.Serializable]
    public struct SystemSettingData
    {
        /// <summary> 选中的数据源 </summary>
        public ushort selectedDropIndex;
        /// <summary> 选中的家庭名称 </summary>
        public string selectedFamilyName;
        /// <summary> 可用数据源集合 </summary>
        public SystemSettingDropData[] dropList;
    }

    [System.Serializable]
    public struct SystemSettingDropData
    {
        public string name;
        public string address;
        public ushort dataType;
    }
}
