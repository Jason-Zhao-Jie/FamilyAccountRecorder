using FamilyAccountRecorder.DataSource.Factory;
using FamilyAccountRecorder.DataSource.File;
using FamilyAccountRecorder.Model.Interface;
using FamilyAccountRecorder.Model.Structs;
using FamilyAccountRecorder.Present;
using FamilyAccountRecorder.ViewInterface;

namespace FamilyAccountRecorder {
    public static class ProcessMain {
        public static IEventManager EventMgr { get; private set; }
        public static IViewCenter ViewCenter { get; private set; }

        public static SystemSettingDropData[] DropList {
            get => settingFile.SystemSetting.dropList;
        }

        public static IDropData SelectedDrop {
            get {
                if (selectedDrop == null) {
                    selectedDrop = DropDataFactory.Create(DropList[settingFile.SystemSetting.selectedDropIndex]);
                }
                return selectedDrop;
            }
        }

        public static string[] FamilyList { get => SelectedDrop.FamilyList; }

        /// <summary>
        /// 初始化逻辑，设定一些必要的管理器
        /// </summary>
        /// <param name="eventMgr"> 事件管理器 </param>
        /// <param name="viewCenter"> 界面管理器 </param>
        public static void Init(IEventManager eventMgr, IViewCenter viewCenter) {
            // 赋值管理器
            EventMgr = eventMgr;
            ViewCenter = viewCenter;

            // 读取配置文件，获得初始数据
            settingFile = new SettingFile();
            if (DropList == null || DropList.Length == 0) {
                settingFile.InitFile();
            }
            familyManager = new FamilyManager(settingFile.SystemSetting.selectedFamilyName);

            // 添加监听事件
            EventMgr.Listen(Event.ShowPanel, OnEventShowPanel);
            EventMgr.Listen(Event.ClosePanel, OnEventClosePanel);

            // 打开窗口
            EventMgr.NotifySync(new EventArgs_ShowPanel(IViewPanel.PanelType.FamilySelect, IViewPanel.PanelLayer.Panel));
        }

        public static IFamilyData SelectFamily(string name) {
            settingFile.SelectFamily(name);
            familyManager = new FamilyManager(name);
            return familyManager.Data;
        }

        private static void OnEventShowPanel(IEventManager.IEventArgs arg) {
            if (arg is EventArgs_ShowPanel showPanelArgs) {
                ViewCenter.ShowPanel(showPanelArgs);
            }
        }

        private static void OnEventClosePanel(IEventManager.IEventArgs arg) {
            if (arg is EventArgs_ClosePanel closePanelArgs) {
                ViewCenter.ClosePanel(closePanelArgs.Type);
            }
        }


        private static SettingFile settingFile;
        private static FamilyManager familyManager;
        private static IDropData selectedDrop;
    }
}
