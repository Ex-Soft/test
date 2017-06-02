using System.Drawing;
using System.IO;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;

namespace TestDEControlsII
{
    public class CustomDateNavigator : DateNavigator
    {
        public CustomDateNavigator()
        {
            SubscribeEvents();
        }

        protected override void Dispose(bool disposing)
        {
            try
            {
                if (!disposing)
                    return;

                UnsubscribeEvents();
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        private void SubscribeEvents()
        {
            CustomWeekNumber += OnCustomWeekNumber;
        }

        private void UnsubscribeEvents()
        {
            CustomWeekNumber -= OnCustomWeekNumber;
        }

        private void OnCustomWeekNumber(object sender, CustomWeekNumberEventArgs e)
        {
            e.WeekNumber = 1;
        }

        protected override BaseStyleControlViewInfo CreateViewInfo()
        {
            //return base.CreateViewInfo();
            return new CustomDateNavigatorViewInfo(this);
        }

        protected override void OnAfterUpdateViewInfo()
        {
            base.OnAfterUpdateViewInfo();
        }
    }

    public class CustomDateNavigatorViewInfo : DateNavigatorViewInfo
    {
        public CustomDateNavigatorViewInfo(CalendarControlBase owner) : base(owner)
        {}

        protected override CalendarObjectViewInfo CreateCalendar(int index)
        {
            //DateNavigatorInfoArgs navigatorInfoArgs = !this.Calendar.PrintNavigator ? new DateNavigatorInfoArgs(this.Calendar) : (DateNavigatorInfoArgs)new DateNavigatorPrintInfoArgs(this.Calendar);
            //navigatorInfoArgs.ShowHeader = this.ShowCalendarHeader(index);
            //navigatorInfoArgs.View = this.Calendar.View;
            //return (CalendarObjectViewInfo)navigatorInfoArgs;

            return base.CreateCalendar(index);
        }
    }

    public class CustomCellStyleProvider : ICalendarCellStyleProvider
    {
        DateNavigator _dateNavigator;

        public CustomCellStyleProvider(DateNavigator dateNavigator)
        {
            _dateNavigator = dateNavigator;
        }

        public void UpdateAppearance(CalendarCellStyle cell)
        {
            WorkDaysCollection workDays = _dateNavigator.SchedulerControl.WorkDays;

            if (workDays.IsHoliday(cell.Date))
            {
                switch (cell.State)
                {
                    // Highlight dates hovered over with the mouse.
                    case (DevExpress.Utils.Drawing.ObjectState.Hot):
                        cell.Appearance.ForeColor = Color.DarkGoldenrod;
                        cell.Appearance.BackColor = Color.PaleGreen;
                        break;
                    // Highlight selection.
                    case (DevExpress.Utils.Drawing.ObjectState.Selected):
                        cell.Appearance.ForeColor = Color.Gold;
                        cell.Appearance.BackColor = Color.Green;
                        break;
                    default:
                        cell.Appearance.ForeColor = Color.Green;
                        cell.Appearance.BackColor = Color.Gold;
                        break;
                }
            }

            // Display an image for the dates which contains appointments.
            if (cell.IsSpecial)
            {
                cell.Appearance.Font = new Font(cell.Appearance.Font, FontStyle.Regular);
                var form = _dateNavigator.FindForm() as MainForm;
                if (form != null)
                    cell.Image = Image.FromFile(Path.Combine(form.CurrentDirectory, "appointment_icon.png"));
            }
        }
    }

    public class CustomCellStyleProviderII : ICalendarCellStyleProvider
    {
        public void UpdateAppearance(CalendarCellStyle cell)
        {
            if (cell.Date.Day%2 == 0)
                cell.Appearance.Font = new Font(cell.Appearance.Font, FontStyle.Bold);
            else
            {
                if (cell.Active)
                    cell.Appearance.BackColor = Color.HotPink;
                else
                    cell.Appearance.BackColor = Color.LightPink;
            }
        }
    }
}

/*
CalendarObjectViewInfoBase
->
CalendarObjectViewInfo
->
DateNavigatorBaseInfoArgs
->
DateNavigatorInfoArgs
->
DateNavigatorBoldedInfoArgs


CalendarCellViewInfo
->
DateNavigatorDayNumberCellInfo


BaseControlViewInfo
->
BaseStyleControlViewInfo
->
CalendarViewInfoBase
->
CalendarViewInfo
->
DateNavigatorViewInfo
->
CustomDateNavigatorViewInfo (my)
*/