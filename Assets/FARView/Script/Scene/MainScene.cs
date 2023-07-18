using System;
using UnityEngine;
using FamilyAccountRecorder.View.Constants;
using System.Collections.Generic;
using FamilyAccountRecorder.Model.Interface;

namespace FamilyAccountRecorder.View
{
    public class MainScene : MonoBehaviour
    {

        [SerializeField] private GameObject dropSelectPanel;
        [SerializeField] private GameObject familyManagerPanel;
        [SerializeField] private GameObject familySettingPanel;
        [SerializeField] private RectTransform[] panelRoots;

        private void Awake()
        {
            panelPrefabs.Add(PanelType.DropSelect, dropSelectPanel);
            panelPrefabs.Add(PanelType.FamilyManager, familyManagerPanel);
            panelPrefabs.Add(PanelType.FamilySetting, familySettingPanel);
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

        private void OnEvent(Constants.Event e, ulong key, params object[] data)
        {
            switch (e)
            {
                case Constants.Event.ShowPanel:
                    OnEventShowPanel(key, data);
                    break;
                case Constants.Event.ClosePanel:
                    OnEventClosePanel(key);
                    break;
            }
        }

        private void OnEventShowPanel(ulong type, params object[] data)
        {
            ulong layer = (ulong)data[0];
            AViewPanel panel;
            if (openedPanels.ContainsKey(type))
            {
                panel = openedPanels[type];
            }
            else
            {
                panel = Instantiate(panelPrefabs[type]).GetComponent<AViewPanel>();
                openedPanels.Add(type, panel);
                panel.Init(data);
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
