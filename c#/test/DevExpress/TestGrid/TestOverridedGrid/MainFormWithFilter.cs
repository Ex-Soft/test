//#define USE_DB

using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Utils.Filtering.Internal;
using DevExpress.Xpo;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Localization;
using TestDB;

namespace TestOverridedGrid
{
    public partial class MainForm
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Localize();
        }

        private static void Localize()
        {
            Localizer.Active = new CustomLocalizer();
            GridLocalizer.Active = new CustomGridLocalizer();
            FilterUIElementLocalizer.Active = new CustomFilterUIElementLocalizer();
        }

        private void SimpleButtonSetColumnFilterPopupMaxRecordsCountClick(object sender, EventArgs e)
        {
            #if !USE_DB
                customGridViewWithFilter.OptionsFilter.ColumnFilterPopupMaxRecordsCount = GetColumnFilterPopupMaxRecordsCount();
            #endif
        }

        private int GetColumnFilterPopupMaxRecordsCount()
        {
            int columnFilterPopupMaxRecordsCount;

            if (!int.TryParse(textEditColumnFilterPopupMaxRecordsCount.Text, out columnFilterPopupMaxRecordsCount))
                columnFilterPopupMaxRecordsCount = -1;

            return columnFilterPopupMaxRecordsCount;
        }

        private void InitializeComponentWithFilter()
        {
            gridControlWithFilter.DataSource = CreateDataSourceWithFilter();
            SimpleButtonSetColumnFilterPopupMaxRecordsCountClick(null, EventArgs.Empty);

            //customGridViewWithFilter.OptionsFilter.ColumnFilterPopupMaxRecordsCount = 0;
        }

        private static object CreateDataSourceWithFilter()
        {
            #if USE_DB
                //return new XPCollection<Staff>(new Session());
                return new XPCollection<TestDetail>(new Session());
            #else

                var result = new List<ClassForDataSourceWithFilter>();

                var id = 0;
                for (var i = 0; i < 26; ++i)
                    for (var j = 0; j < 10; ++j)
                    {
                        result.Add(new ClassForDataSourceWithFilter
                            (
                                id++,
                                Enumerable.Repeat(new string((char)(i + 0x41), 1), 5)
                                    .Aggregate(string.Empty, (str, next) =>
                                    {
                                        if (!string.IsNullOrWhiteSpace(str))
                                            str += " ";
                                        return str + next;
                                    })
                            ));
                    }
                    
                return result;

            #endif
        }
    }

    #if !USE_DB

        public class ClassForDataSourceWithFilter
        {
            public int Id { get; set; }
            public string FString { get; set; }
            public DateTime FDateTime { get; set; }
            
            public ClassForDataSourceWithFilter(int id = 0, string fString = "")
            {
                Id = id;
                FString = fString;
                FDateTime = DateTime.Now;
            }

            public ClassForDataSourceWithFilter(ClassForDataSourceWithFilter obj) : this(obj.Id, obj.FString)
            {}
    }

    #endif
}
