namespace FamilyAccountRecorder.Model.Structs
{
    /// <summary>
    /// 系统设置存储数据
    /// </summary>
    [System.Serializable]
    public struct DropSettingData
    {
        /// <summary> 数据源显示名称 </summary>
        public string name;
        /// <summary> 家庭列表 </summary>
        public string[] familyList;
    }
}