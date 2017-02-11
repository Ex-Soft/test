using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.Xpo;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using DevExpress.Schedule;
using DevExpress.XtraBars;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Drawing;
using DevExpress.XtraEditors.Calendar;

namespace TestDE16WinApp
{
    public partial class MainForm : XtraForm
    {
        public string CurrentDirectory;


        public MainForm()
        {
            InitializeComponent();

            XpoDefault.ConnectionString = Utils.GetConnectionString();

            CurrentDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;
            if (CurrentDirectory.IndexOf("bin") != -1)
                CurrentDirectory = CurrentDirectory.Substring(0, CurrentDirectory.LastIndexOf("bin", CurrentDirectory.Length - 1));


            #region DateNavigator size (https://www.devexpress.com/Support/Center/Question/Details/T320427)

            // a) for horizontal calendars:
            dateNavigator2.CellPadding = new System.Windows.Forms.Padding(1);            // default = { { Left = -1,Top = -1,Right = -1,Bottom = -1} }
            dateNavigator2.MonthHeaderPadding = new System.Windows.Forms.Padding(-5);    // default = { { Left = -1,Top = -1,Right = -1,Bottom = -1} }

            // b) for vertical calendars:
            dateNavigator3.CalendarIndent = 0;                                           // default = -1
            dateNavigator3.CellPadding = new System.Windows.Forms.Padding(0);            // default = { { Left = -1,Top = -1,Right = -1,Bottom = -1} }
            dateNavigator3.MonthHeaderPadding = new System.Windows.Forms.Padding(0);     // default = { { Left = -1,Top = -1,Right = -1,Bottom = -1} }

            dateNavigator4.HeaderPadding = new System.Windows.Forms.Padding(8);
            dateNavigator4.CellPadding = new System.Windows.Forms.Padding(0);
            dateNavigator4.MonthHeaderPadding = new System.Windows.Forms.Padding(-12, -12, -12, -12);
            dateNavigator4.AutoSize = true;
            dateNavigator4.ShowTodayButton = false;
            dateNavigator4.WeekDayAbbreviationLength = 1;

            dateNavigator5.CalendarIndent = 0;
            dateNavigator5.CellPadding = new System.Windows.Forms.Padding(0);
            dateNavigator5.MonthHeaderPadding = new System.Windows.Forms.Padding(0);
            dateNavigator5.AutoSize = true;
            dateNavigator5.ShowTodayButton = false;
            dateNavigator5.WeekDayAbbreviationLength = 1;

            dateNavigator6.ShowMonthNavigationButtons = DefaultBoolean.False;
            dateNavigator6.ShowYearNavigationButtons = DefaultBoolean.False;

            #endregion

            barEditItem1.EditValue = DateTime.Now;
            barEditItem2.EditValue = DateTime.Now;
            barEditItem3.EditValue = DateTime.Now;

            barEditItem1.EditValueChanged += BarEditItem_EditValueChanged;

            var now = DateTime.Now;
            //calendarControl.StartDate = new DateTime(1900, now.Month, 1);
            //calendarControl.SetSelection(new DateTime(1900, now.Month, now.Day));
            //calendarControl.TodayDate = new DateTime(1900, now.Month, now.Day);
            calendarControl.DateTime = new DateTime(1900, now.Month, now.Day);

            dateNavigator7.ShowWeekNumbers = false;
            dateNavigator7.ShowTodayButton = false;
            dateNavigator7.ShowHeader = false;
            dateNavigator7.ShowMonthHeaders = false;

            //checkedListBoxControl1.AllowGrayed = true;
            checkedListBoxControl1.CheckOnClick = true;
            checkedListBoxControl1.Items.AddRange(new[]
            {
                new CheckedListBoxItem("January", false),
                new CheckedListBoxItem("February", false),
                new CheckedListBoxItem("March", true),
                new CheckedListBoxItem("April", false),
                new CheckedListBoxItem("May", false),
                new CheckedListBoxItem("June", true),
                new CheckedListBoxItem("July", true),
                new CheckedListBoxItem("August", false),
                new CheckedListBoxItem("September", false),
                new CheckedListBoxItem("October", false),
                new CheckedListBoxItem("November", false),
                new CheckedListBoxItem("December", false)
            });
        }

        private void BarEditItem_EditValueChanged(object sender, EventArgs e)
        {
            BarEditItem barEditItem;
            if ((barEditItem = sender as BarEditItem) == null)
                return;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            customDateNavigator1.CellStyleProvider = new CustomCellStyleProvider(customDateNavigator1);
            schedulerControl1.BeginUpdate();
            schedulerControl1.OptionsView.FirstDayOfWeek = FirstDayOfWeek.Sunday;
            schedulerControl1.WorkDays.Clear();
            // Specify working days of a week. Friday and Saturday are weekend holidays.
            schedulerControl1.WorkDays.Add(WeekDays.Sunday | WeekDays.Monday
                  | WeekDays.Tuesday | WeekDays.Wednesday
                  | WeekDays.Thursday);
            GenerateHolidaysFor2015();
            schedulerControl1.EndUpdate();
            schedulerControl1.ActiveViewType = SchedulerViewType.Day;
            customDateNavigator1.HighlightHolidays = true;
            customDateNavigator1.DateTime = new DateTime(2015, 02, 26);

            customDateNavigator2.CellStyleProvider = new CustomCellStyleProviderII();
            var cb = new ContextButton()
            {
                Alignment = ContextItemAlignment.TopNear,
                Visibility = ContextItemVisibility.Hidden

            };
            customDateNavigator2.CellSize = new Size(50, 50);
            customDateNavigator2.ContextButtons.Add(cb);
            customDateNavigator2.ContextButtonCustomize += customDateNavigator2_ContextButtonCustomize;
            customDateNavigator2.CustomDrawDayNumberCell += customDateNavigator2_CustomDrawDayNumberCell;
        }

        private readonly Holiday[] _kuwaitHolidays2015 = {
            new Holiday(new DateTime(2015, 01, 1), "New Year's Day"),
            new Holiday(new DateTime(2015, 01, 3), "The Prophet's Birthday"),
            new Holiday(new DateTime(2015, 02, 25), "National Day"),
            new Holiday(new DateTime(2015, 02, 26), "Liberation Day"),
            new Holiday(new DateTime(2015, 05, 16), "Isra and Miraj"),
            new Holiday(new DateTime(2015, 07, 18), "Eid al Fitr (End of Ramadan)"),
            new Holiday(new DateTime(2015, 07, 19), "Eid al Fitr holiday"),
            new Holiday(new DateTime(2015, 07, 20), "Eid al Fitr holiday"),
            new Holiday(new DateTime(2015, 09, 23), "Waqfat Arafat Day"),
            new Holiday(new DateTime(2015, 09, 24), "Eid al Adha (Feast of Sacrifice)"),
            new Holiday(new DateTime(2015, 09, 25), "Eid al Adha holiday"),
            new Holiday(new DateTime(2015, 09, 26), "Eid al Adha holiday"),
            new Holiday(new DateTime(2015, 10, 15), "Hejira New Year (Islamic New Year)"),
            new Holiday(new DateTime(2015, 12, 24), "The Prophet's Birthday"),
        };

        private void GenerateHolidaysFor2015()
        {
            foreach (Holiday item in _kuwaitHolidays2015)
            {
                schedulerControl1.WorkDays.Add(item);
            }
        }

        private void schedulerControl1_CustomDrawDayHeader(object sender, CustomDrawObjectEventArgs e)
        {
            #region #CustomDrawDayHeader
            // Check whether the current object is a Day Header.
            SchedulerHeader header = e.ObjectInfo as SchedulerHeader;
            if (header != null)
            {
                // Check whether the current date is a known holiday.
                Holiday hol = FindHoliday(header.Interval.Start.Date);
                if (hol != null)
                {
                    header.Caption = hol.DisplayName;
                    e.DrawDefault();
                    // Add the holiday name to the day header's caption.
                    Image img = Image.FromFile(Path.Combine(CurrentDirectory, "Kuwait.png"));
                    Rectangle imgRect = header.ImageBounds;
                    imgRect.Width = header.ImageBounds.Height * img.Width / img.Height;
                    imgRect.X = header.ImageBounds.X + header.ImageBounds.Width - imgRect.Width;
                    e.Graphics.DrawImage(img, imgRect);
                    e.Handled = true;
                }
            }
            #endregion #CustomDrawDayHeader
        }

        Holiday FindHoliday(DateTime date)
        {
            WorkDaysCollection workDays = schedulerControl1.WorkDays;
            return workDays.OfType<Holiday>().FirstOrDefault(hol => hol.Date == date);
        }

        private void SimpleButtonGridInWindow_Click(object sender, EventArgs e)
        {
            using (var form = new GridForm1())
            {
                form.ShowDialog(this);
            }
        }

        private void customDateNavigator2_ContextButtonCustomize(object sender, CalendarContextButtonCustomizeEventArgs e)
        {
            if (e.Cell.Date.Day%2 != 0)
            {
                e.Item.Glyph = Properties.Resources.Party;
                e.Item.Visibility = ContextItemVisibility.Visible;
                e.Item.ToolTip = "blah-blah-blah";
                e.Item.ShowToolTips = true;
            }
        }

        private void customDateNavigator2_CustomDrawDayNumberCell(object sender, CustomDrawDayNumberCellEventArgs e)
        {
            if (e.Highlighted)
            {
                
            }

            if (e.Selected)
            {
                e.Style.BackColor = Color.Aqua;
                e.Handled = true;
            }
        }

        private void dateNavigator_Click(object sender, EventArgs e)
        {
            DateNavigator dateNavigator;
            if ((dateNavigator = sender as DateNavigator) == null)
                return;

            CalendarHitInfo info = dateNavigator.GetHitInfo(e as MouseEventArgs);
            if (info.HitTest == CalendarHitInfoType.DecMonth || info.HitTest == CalendarHitInfoType.IncMonth)
                Debug.WriteLine("Month is changed");
        }

        private void dateNavigator_CustomDrawDayNumberCell(object sender, CustomDrawDayNumberCellEventArgs e)
        {
            DateNavigator dateNavigator;
            if ((dateNavigator = sender as DateNavigator) == null)
                return;

            var calendarHitInfo = dateNavigator.GetHitInfo(dateNavigator.PointToClient(MousePosition));

            var dateNavigatorDayNumberCellInfo = e.ViewInfo;
            var dateNavigatorInfoArgs = dateNavigatorDayNumberCellInfo.ViewInfo;

            if (e.Date.Month == dateNavigatorInfoArgs.CurrentDate.Month /*e.Highlighted*/)
            {
                e.Style.Font = new Font(e.Style.Font, FontStyle.Bold);
                //e.Handled = true;
            }
        }

        private void simpleButtonBarInWindow_Click(object sender, EventArgs e)
        {
            using (var form = new BarForm())
            {
                form.ShowDialog(this);
            }
        }

        private void simpleButtonGetDateNavigatorSelects_Click(object sender, EventArgs e)
        {
            var listOfDateTimeI = new List<DateTime>();
            foreach(var range in dateNavigator1.SelectedRanges.Select(r => new { r.StartDate, EndDate = r.EndDate.AddDays(-1) }))
                listOfDateTimeI.AddRange(Range(range.StartDate, range.EndDate));

            var listOfDateTimeII = dateNavigator1.SelectedRanges.SelectMany(r => Range(r.StartDate, r.EndDate.AddDays(-1)));
        }

        private static IEnumerable<DateTime> Range(DateTime startDate, DateTime endDate)
        {
            return Enumerable.Range(0, (int) (endDate - startDate).TotalDays + 1).Select(x => startDate.AddDays(x));
        }

        private void simpleButtonMasterDetail_Click(object sender, EventArgs e)
        {
            using (var form = new GridFormMasterDetailI())
            {
                form.ShowDialog(this);
            }
        }

        private void simpleButtonGetCheckedListBoxInfo_Click(object sender, EventArgs e)
        {
            var checkedIndices = checkedListBoxControl1.CheckedIndices.OfType<int>().ToArray();
            var checkedItems = checkedListBoxControl1.CheckedItems.OfType<CheckedListBoxItem>().ToArray();
        }

        private void simpleButtonHint_Click(object sender, EventArgs e)
        {
            using (var form = new GridForm2())
            {
                form.ShowDialog(this);
            }
        }
    }
}
