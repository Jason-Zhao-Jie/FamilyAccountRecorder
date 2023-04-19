using UnityEngine;

namespace FamilyAccountRecorder.Model.Interface
{
    public abstract class AViewPanel : MonoBehaviour, IViewPanel
    {
        public void Open(ulong layerIndex, object layerRoot)
        {
            var rect = layerRoot as RectTransform;
            gameObject.transform.SetParent(rect, false);
            gameObject.transform.localScale = Vector3.one;
            gameObject.SetActive(true);
        }
        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}
