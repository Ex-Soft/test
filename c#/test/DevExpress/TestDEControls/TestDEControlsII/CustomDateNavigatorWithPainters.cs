using System.Windows.Forms;
using DevExpress.Utils.Drawing;
using DevExpress.Utils.Drawing.Animation;
using DevExpress.XtraEditors.Calendar;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;

namespace TestDEControlsII
{
    public class CustomDateNavigatorWithPainters : DateNavigator
    {
        public CustomDateNavigatorWithPainters()
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
        }

        private void UnsubscribeEvents()
        {
        }

        protected override void OnPropertiesChanged()
        {
            base.OnPropertiesChanged();
        }


        protected override void Init()
        {
            base.Init();

            CalendarIndent = 0;
            HeaderPadding = new Padding(-1);
            CellPadding = new Padding(0);
            MonthHeaderPadding = new Padding(-12);
            AutoSize = true;
            ShowHeader = false;
            ShowMonthHeaders = false;
            ShowWeekNumbers = false;
            ShowFooter = false;
            WeekDayAbbreviationLength = 1;
        }

        protected override BaseControlPainter CreatePainter()
        {
            return new CustomDateNavigatorPainter();
        }
    }

    public class CustomDateNavigatorPainter : DateNavigatorPainterBase
    {
        public override CalendarHeaderObjectPainter HeaderPainter
        {
            get
            {
                return new CustomCalendarHeaderObjectPainter();
            }
        }

        public override CalendarFooterObjectPainter FooterPainter
        {
            get
            {
                return new CustomCalendarFooterObjectPainter();
            }
        }

        protected override CalendarObjectPainterBase GetCalendarPainter()
        {
            return new CustomDateNavigatorObjectPainter();
        }
    }

    public class CustomCalendarHeaderObjectPainter : CalendarHeaderObjectPainter
    {
        protected override void DrawCaptions(CalendarHeaderInfoArgs info)
        {
            base.DrawCaptions(info);
        }

        protected override void DrawContent(CalendarHeaderInfoArgs info)
        {
            base.DrawContent(info);
        }

        protected override void DrawNavigationButton(CalendarHeaderInfoArgs info, CalendarNavigationButtonViewInfo button)
        {
            base.DrawNavigationButton(info, button);
        }
    }

    public class CustomCalendarFooterObjectPainter : CalendarFooterObjectPainter
    {
        
    }

    public class CustomDateNavigatorObjectPainter : DateNavigatorObjectPainter
    {
        protected override void DrawWeekDayAbbreviation(CalendarControlObjectInfoArgs e, CalendarCellViewInfo cell)
        {
            //base.DrawWeekDayAbbreviation(e, cell);
        }

        //protected override void DrawWeekdaysAbbreviation(CalendarControlObjectInfoArgs e)
        //{
        //    base.DrawWeekdaysAbbreviation(e);
        //}

        protected override void DrawWeekdaysAbbreviationSeparator(CalendarControlObjectInfoArgs e)
        {
            //base.DrawWeekdaysAbbreviationSeparator(e);
        }
    }
}
