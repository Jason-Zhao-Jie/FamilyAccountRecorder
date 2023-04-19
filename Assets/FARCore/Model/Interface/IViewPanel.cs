using UnityEngine;

namespace FamilyAccountRecorder.Model.Interface
{
    public interface IViewPanel
    {
        void Open(ulong layerIndex, object layerRoot);
        void Close();
    }
}
