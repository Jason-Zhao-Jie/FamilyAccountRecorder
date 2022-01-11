namespace ArmyAnt.Common.PlatformInterface
{
    public interface IQuickStorage
    {
        public void SetItem<T>(string key, T value);
        public T GetItem<T>(string key);
        public void Clear();
    }
}
