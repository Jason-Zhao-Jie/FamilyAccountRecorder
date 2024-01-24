namespace FamilyAccountRecorder.Model.Utility
{
    public class DataDic<K, V> : System.Collections.Generic.Dictionary<K, V> where V : struct
    {
        public virtual V Get(K key)
        {
            if (ContainsKey(key))
            {
                return this[key];
            }
            else
            {
                return default;
            }
        }

        public virtual K[] GetAll()
        {
            var ret = new K[Count];
            Keys.CopyTo(ret, 0);
            return ret;
        }

        public virtual void Set(K key, V value)
        {
            if (ContainsKey(key))
            {
                Remove(key);
            }
            Add(key, value);
        }
    }
}
