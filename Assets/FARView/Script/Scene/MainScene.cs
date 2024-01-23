using System;
using UnityEngine;
using FamilyAccountRecorder.View.Constants;
using System.Collections.Generic;
using FamilyAccountRecorder.Model.Interface;
using FamilyAccountRecorder.Present;
using static FamilyAccountRecorder.Present.EventArgs_ShowPanel;

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
            ViewCenter.EventMgr.Listen(Present.Event.ShowPanel, OnEvent);
            ViewCenter.EventMgr.Listen(Present.Event.ClosePanel, OnEvent);
            ViewCenter.Init();
        }

        // Update is called once per frame
        private void Update()
        {

        }

        private void OnEvent(Present.IEventManager.IEventArgs arg)
        {
            switch (arg.EventId)
            {
                case Present.Event.ShowPanel:
                    if(arg is EventArgs_ShowPanel sp_arg) {
                        OnEventShowPanel(sp_arg.Type, sp_arg.Data);
                    }
                    break;
                case Present.Event.ClosePanel:
                    if (arg is EventArgs_ClosePanel cp_arg) {
                        OnEventClosePanel(cp_arg.Type);
                    }
                    break;
            }
        }

        private void OnEventShowPanel(PanelType type, params object[] data)
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

        private void OnEventClosePanel(PanelType type)
        {
            if (openedPanels.ContainsKey(type))
            {
                var panel = openedPanels[type];
                panel.Close();
            }
        }

        private Dictionary<PanelType, GameObject> panelPrefabs = new Dictionary<PanelType, GameObject>();
        private Dictionary<PanelType, AViewPanel> openedPanels = new Dictionary<PanelType, AViewPanel>();
    }
}
