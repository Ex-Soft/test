using System;
using DevExpress.XtraEditors.Controls;

namespace TestDEControlsII
{
    public class CustomCalendarControl : CalendarControl
    {
        public override void ResetState(object editDate, DateTime dt)
        {
            var now = DateTime.Now;
            var d1900 = new DateTime(1900, now.Month, now.Day);
            base.ResetState(editDate, dt);
            TodayDate = now;
            DateTime = d1900;
        }
    }
}
