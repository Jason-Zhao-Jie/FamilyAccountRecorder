using FamilyAccountRecorder.ViewInterface;

using UnityEngine;

namespace FamilyAccountRecorder.Model.Interface
{
    public abstract class AViewPanel : MonoBehaviour, IViewPanel
    {
        public IViewPanel.PanelType Type { get; }

        public AViewPanel(IViewPanel.PanelType type) {
            Type = type;
        }

        public void Open(IViewPanel.PanelLayer layerIndex, object layerRoot)
        {
            var rect = layerRoot as RectTransform;
            gameObject.transform.SetParent(rect, false);
            gameObject.transform.localScale = Vector3.one;
            gameObject.SetActive(true);
        }

        public abstract void Init(EventArgs_ShowPanel args);

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}
