using FamilyAccountRecorder.Model.Interface;
using FamilyAccountRecorder.ViewInterface;
using FamilyAccountRecorder.ViewInterface.Panels;

using System;

using UnityEngine;
using UnityEngine.UI;

using static FamilyAccountRecorder.View.Prefab.DialogPanel.EventArgs_ShowPanel_DialogPanel;

namespace FamilyAccountRecorder.View.Prefab {
    public class DialogPanel : AViewPanel, IDialogPanel {
        [SerializeField] Text textContent;
        [SerializeField] Text textLeftButton;
        [SerializeField] Text textMidButton;
        [SerializeField] Text textRightButton;

        private EventArgs_ShowPanel_DialogPanel.DialogData dialogData;
        public EventArgs_ShowPanel_DialogPanel.DialogData DialogData {
            get => dialogData;
            set {
                dialogData = DialogData;
                textContent.text = dialogData.content;
                textLeftButton.text = dialogData.leftButtonText;
                textMidButton.text = dialogData.midButtonText;
                textRightButton.text = dialogData.rightButtonText;
            }
        }

        public class EventArgs_ShowPanel_DialogPanel : EventArgs_ShowPanel<DialogData> {
            public struct DialogData {
                public string content;
                public bool isLeftButtonShown;
                public string leftButtonText;
                public bool isMidButtonShown;
                public string midButtonText;
                public bool isRightButtonShown;
                public string rightButtonText;
            }

            public enum EDialogResult {
                Positive,
                Negative,
                Others
            }

            public static EventArgs_ShowPanel_DialogPanel GetResultDialogData(string content, Action<EDialogResult> callback, string positiveButtonText, string negativeButtonText = null, string othersButtonText = null) {
                int buttonNum = ((negativeButtonText == null) ? 0 : 1) + ((othersButtonText == null) ? 0 : 1) + 1;
                return new EventArgs_ShowPanel_DialogPanel {
                    Data = new DialogData {
                        content = content,
                        isLeftButtonShown = buttonNum > 1,
                        leftButtonText = positiveButtonText,
                        isMidButtonShown = buttonNum != 2,
                        midButtonText = (buttonNum == 1) ? positiveButtonText : othersButtonText,
                        isRightButtonShown = buttonNum > 1,
                        rightButtonText = negativeButtonText,
                    },
                    LeftButtonCallback = () => {
                        callback(EDialogResult.Positive);
                        return true;
                    },
                    MidButtonCallback = () => {
                        callback((buttonNum == 1) ? EDialogResult.Positive : EDialogResult.Negative);
                        return true;
                    },
                    RightButtonCallback = () => {
                        callback(EDialogResult.Negative);
                        return true;
                    },
                };
            }

            public Func<bool> LeftButtonCallback;
            public Func<bool> MidButtonCallback;
            public Func<bool> RightButtonCallback;
            public EventArgs_ShowPanel_DialogPanel() : base(IViewPanel.PanelType.Dialog, IViewPanel.PanelLayer.Popup) { }
        }

        public DialogPanel() : base(IViewPanel.PanelType.Dialog) { }

        public event Func<bool> OnLeftClick;
        public event Func<bool> OnMidClick;
        public event Func<bool> OnRightClick;

        public override void Init(EventArgs_ShowPanel args) {
            if(args is EventArgs_ShowPanel_DialogPanel data) {
                DialogData = data.Data;
                OnLeftClick += data.LeftButtonCallback;
                OnMidClick += data.MidButtonCallback;
                OnRightClick += data.RightButtonCallback;
            }
        }

        public void OnClickLeft() {
            if (OnLeftClick != null && OnLeftClick()) {
                ProcessMain.EventMgr.NotifySync(new EventArgs_ClosePanel(Type));
            }
        }

        public void OnClickMid() {
            if (OnMidClick != null && OnMidClick()) {
                ProcessMain.EventMgr.NotifySync(new EventArgs_ClosePanel(Type));
            }
        }

        public void OnClickRight() {
            if (OnRightClick != null && OnRightClick()) {
                ProcessMain.EventMgr.NotifySync(new EventArgs_ClosePanel(Type));
            }
        }
    }
}
