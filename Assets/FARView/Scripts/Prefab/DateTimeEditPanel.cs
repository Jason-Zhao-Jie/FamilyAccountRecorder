using FamilyAccountRecorder.Model.Interface;
using FamilyAccountRecorder.ViewInterface;
using FamilyAccountRecorder.ViewInterface.Panels;

using System;

using UnityEngine;
using UnityEngine.UI;

namespace FamilyAccountRecorder.View.Prefab
{
    public class DateTimeEditPanel : AViewPanel, IDateTimeEditPanel {
        [SerializeField] private InputField textYear;
        [SerializeField] private InputField textMonth;
        [SerializeField] private InputField textDayInMonth;
        [SerializeField] private InputField textHour;
        [SerializeField] private InputField textMinute;
        [SerializeField] private InputField textSecond;

        private DateTime value = DateTime.Now;
        public DateTime Value {
            get => value;
            set {
                this.value = value;
                textYear.text = value.Year.ToString();
                textMonth.text = value.Month.ToString();
                textDayInMonth.text = value.Day.ToString();
                textHour.text = value.Hour.ToString();
                textMinute.text = value.Minute.ToString();
                textSecond.text = value.Second.ToString();
            }
        }

        public event Action<DateTime> OnCommit;

        public DateTimeEditPanel() : base(IViewPanel.PanelType.DateTimeEdit) {}

        public override void Init(EventArgs_ShowPanel args) {
            if(args is EventArgs_ShowPanelWithResult<DateTime> commitArgs) {
                Value = commitArgs.Data;
                OnCommit = commitArgs.OnCommit;
            }else if(args is EventArgs_ShowPanel<DateTime> dataArgs) {
                Value = dataArgs.Data;
            }
        }

        public void OnClickOK() {
            var year = int.Parse(textYear.text);
            var month = int.Parse(textMonth.text);
            var day = int.Parse(textDayInMonth.text);
            var hour = int.Parse(textHour.text);
            var minute = int.Parse(textMinute.text);
            var second = int.Parse(textSecond.text);
            Value = new DateTime(year, month, day, hour, minute, second);
            OnCommit(Value);
            CloseSelf();
        }

        public void OnClickReset() {
            Value = value;
        }

        public void OnClickCancel() {
            CloseSelf();
        }

        public void OnYearChange(int delta) {
            var year = int.Parse(textYear.text);
            year += delta;
            if(year < 0) {
                year = 0;
            }
            textYear.text = year.ToString();
        }

        public void OnMonthChange(int delta) {
            var month = int.Parse(textMonth.text);
            month += delta;
            while (month < 1) {
                OnYearChange(-1);
                month += 12;
            }
            while(month > 12) {
                OnYearChange(1);
                month -= 12;
            }
            textMonth.text = month.ToString();
        }

        public void OnDayChange(int delta) {
            var day = int.Parse(textDayInMonth.text);
            day += delta;
            var year = int.Parse(textYear.text);
            var month = int.Parse(textMonth.text);
            var maxDay = DateTime.DaysInMonth(year, month);
            while (day < 1) {
                OnMonthChange(-1);
                year = int.Parse(textYear.text);
                month = int.Parse(textMonth.text);
                maxDay = DateTime.DaysInMonth(year, month);
                day += maxDay;
            }
            while (day > maxDay) {
                OnMonthChange(1);
                year = int.Parse(textYear.text);
                month = int.Parse(textMonth.text);
                maxDay = DateTime.DaysInMonth(year, month);
                day -= maxDay;
            }
            textDayInMonth.text = day.ToString();
        }

        public void OnHourChange(int delta) {
            var hour = int.Parse(textHour.text);
            hour += delta;
            while (hour < 0) {
                OnDayChange(-1);
                hour += 24;
            }
            while (hour > 23) {
                OnDayChange(1);
                hour -= 24;
            }
            textHour.text = hour.ToString();
        }

        public void OnMinuteChange(int delta) {
            var minute = int.Parse(textMinute.text);
            minute += delta;
            while (minute < 0) {
                OnHourChange(-1);
                minute += 60;
            }
            while (minute > 59) {
                OnHourChange(1);
                minute -= 60;
            }
            textMinute.text = minute.ToString();
        }

        public void OnSecondChange(int delta) {
            var second = int.Parse(textSecond.text);
            second += delta;
            while (second < 0) {
                OnMinuteChange(-1);
                second += 60;
            }
            while (second > 59) {
                OnMinuteChange(1);
                second -= 60;
            }
            textSecond.text = second.ToString();
        }
    }
}