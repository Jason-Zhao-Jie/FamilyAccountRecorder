using UnityEngine;
using System.Collections.Generic;
using FamilyAccountRecorder.Model.Interface;
using FamilyAccountRecorder.ViewInterface;
using ArmyAnt.ViewUtil.Components;

namespace FamilyAccountRecorder.View
{
    public sealed class MainScene : EventManager<ViewInterface.Event>, IEventManager, IViewCenter {
        [SerializeField] private GameObject dialogPanel;
        [SerializeField] private GameObject dataTimeEditPanel;
        [SerializeField] private GameObject systemSettingPanel;
        [SerializeField] private GameObject dropSelectPanel;
        [SerializeField] private GameObject familySelectPanel;
        [SerializeField] private GameObject familySettingPanel;
        [SerializeField] private GameObject memberManagePanel;
        [SerializeField] private GameObject tagManage;
        [SerializeField] private GameObject billListMain;

        [SerializeField] private RectTransform[] panelRoots;

        private void Awake() {
            panelPrefabs.Add(IViewPanel.PanelType.Dialog, dialogPanel);
            panelPrefabs.Add(IViewPanel.PanelType.DateTimeEdit, dataTimeEditPanel);
            panelPrefabs.Add(IViewPanel.PanelType.SystemSetting, systemSettingPanel);
            panelPrefabs.Add(IViewPanel.PanelType.DropSelect, dropSelectPanel);
            panelPrefabs.Add(IViewPanel.PanelType.FamilySelect, familySelectPanel);
            panelPrefabs.Add(IViewPanel.PanelType.FamilySetting, familySettingPanel);
            panelPrefabs.Add(IViewPanel.PanelType.MemberManage, memberManagePanel);
            panelPrefabs.Add(IViewPanel.PanelType.TagManage, tagManage);
            panelPrefabs.Add(IViewPanel.PanelType.BillListMain, billListMain);

            ProcessMain.Init(this, this);
        }

        // Start is called before the first frame update
        private void Start()
        {

        }

        // Update is called once per frame
        protected sealed override void Update()
        {
            base.Update();
        }

        public IViewPanel ShowPanel(EventArgs_ShowPanel args) {
            AViewPanel panel;
            if (openedPanels.ContainsKey(args.Type)) {
                panel = openedPanels[args.Type];
            } else {
                panel = Instantiate(panelPrefabs[args.Type]).GetComponent<AViewPanel>();
                openedPanels.Add(args.Type, panel);
                panel.Init(args);
            }
            panel.Open(args.Layer, panelRoots[(int)args.Layer]);
            return panel;
        }

        public bool ClosePanel(IViewPanel.PanelType type) {
            if (openedPanels.ContainsKey(type)) {
                var panel = openedPanels[type];
                panel.Close();
                return true;
            }
            return false;
        }

        private readonly Dictionary<IViewPanel.PanelType, GameObject> panelPrefabs = new();
        private readonly Dictionary<IViewPanel.PanelType, AViewPanel> openedPanels = new();
    }
}
