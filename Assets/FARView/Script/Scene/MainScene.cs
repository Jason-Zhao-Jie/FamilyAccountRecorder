using System;
using UnityEngine;
using FamilyAccountRecorder.View.Constants;
using System.Collections.Generic;
using FamilyAccountRecorder.Model.Interface;

namespace FamilyAccountRecorder.View
{
    public class MainScene : MonoBehaviour
    {

        [SerializeField]
        public GameObject dropSelectPanel;
        [SerializeField]
        public GameObject familyManagerPanel;
        [SerializeField]
        public RectTransform[] panelRoots;

        private void Awake()
        {
            panelPrefabs.Add(PanelType.DropSelect, dropSelectPanel);
            panelPrefabs.Add(PanelType.FamilyManager, familyManagerPanel);
        }

        // Start is called before the first frame update
        private void Start()
        {
            ViewCenter.EventMgr.Listen(Constants.Event.ShowPanel, OnEvent);
            ViewCenter.EventMgr.Listen(Constants.Event.ClosePanel, OnEvent);
            ViewCenter.Init();
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
                case Constants.Event.ClosePanel:
                    OnEventClosePanel(data[0]);
                    break;
            }
        }

        private void OnEventShowPanel(ulong type, ulong layer)
        {
            AViewPanel panel;
            if (openedPanels.ContainsKey(type))
            {
                panel = openedPanels[type];
            }
            else
            {
                panel = Instantiate(panelPrefabs[type]).GetComponent<AViewPanel>();
                openedPanels.Add(type, panel);
            }
            panel.Open(layer, panelRoots[layer]);
        }

        private void OnEventClosePanel(ulong type)
        {
            if (openedPanels.ContainsKey(type))
            {
                var panel = openedPanels[type];
                panel.Close();
            }
        }

        private Dictionary<ulong, GameObject> panelPrefabs = new Dictionary<ulong, GameObject>();
        private Dictionary<ulong, AViewPanel> openedPanels = new Dictionary<ulong, AViewPanel>();
    }
}
