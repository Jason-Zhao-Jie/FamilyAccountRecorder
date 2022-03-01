using System.Text;
using ArmyAnt.Manager;

namespace FamilyAccountRecorder.Utility
{
    /// <summary>
    /// 用于保存本地数据的 Json 文件接口
    /// </summary>
    public class JsonDataDicHelper
    {
        public T UpdateLoad<T>(params string[] path)
        {
            var f = IOManager.LoadFromFile(path);
            var str = Encoding.UTF8.GetString(f);
            var data = UnityEngine.JsonUtility.FromJson<T>(str);
            return data;
        }

        public void UpdateSave<T>(T value, params string[] path)
        {
            var str = UnityEngine.JsonUtility.ToJson(value);
            var bts = Encoding.UTF8.GetBytes(str);
            IOManager.SaveToFile(bts, path);
        }

    }

}
