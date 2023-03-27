using System;
using UnityEngine;
using FamilyAccountRecorder.View.Constants;
using System.Collections.Generic;

namespace FamilyAccountRecorder.View
{
    public class MainScene : MonoBehaviour
    {

        [SerializeField]
        public GameObject familyManagerPanel;
        [SerializeField]
        public RectTransform[] panelRoots;

        private void Awake()
        {
            panels.Clear();
            panels.Add(PanelType.FamilyManager, familyManagerPanel);
        }

        // Start is called before the first frame update
        private void Start()
        {
            Center.EventMgr.Listen(Constants.Event.ShowPanel, OnEvent);
            Center.EventMgr.Notify(Constants.Event.ShowPanel, PanelType.FamilyManager, PanelLayer.Panel);

        }

        // Update is called once per frame
        private void Update()
        {

        }

        private void OnEvent(Constants.Event e, params ulong[] data)
        {
            switch (e)
            {
                case Constants.Event.ShowPanel:
                    OnEventShowPanel(data[0], data[1]);
                    break;
            }
        }

        private void OnEventShowPanel(ulong type, ulong layer)
        {
            var panel = Instantiate(panels[type]);
            panel.transform.SetParent(panelRoots[layer], false);
            panel.transform.localScale = Vector3.one;
        }

        private Dictionary<ulong, GameObject> panels = new Dictionary<ulong, GameObject>();
    }
}
