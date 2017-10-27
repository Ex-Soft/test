//#define USE_DB

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
            FilteringLocalizer.Active = new CustomFilteringLocalizer();
            FilterUIElementLocalizer.Active = new CustomFilterUIElementLocalizer();
        }

        private void InitializeComponentWithFilter()
        {
            gridControlWithFilter.DataSource = CreateDataSourceWithFilter();
            
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
                var dt = DateTime.Now;
                for (var i = 0; i < 26; ++i)
                    for (var j = 0; j < 10; ++j)
                    {
                        result.Add(new ClassForDataSourceWithFilter
                            (
                                id++,
                                CreateString(i, 1),
                                CreateString(i, 2),
                                CreateString(i, 3),
                                dt.AddDays(i).AddHours(j).Ticks,
                                j % 2 == 0
                            ));
                    }
                    
                return result;

            #endif
        }

        #if !USE_DB

            private static string CreateString(int letterNo, int count)
            {
                return Enumerable.Repeat(new string((char)(letterNo + 0x41), 1), count)
                                    .Aggregate(string.Empty, (str, next) =>
                                    {
                                        if (!string.IsNullOrWhiteSpace(str))
                                            str += " ";
                                        return str + next;
                                    });
            }

        #endif
    }

    #if !USE_DB

        public class ClassForDataSourceWithFilter
        {
            public int Id { get; set; }
            public string FString1 { get; set; }
            public string FString2 { get; set; }
            public string FString3 { get; set; }
            public DateTime FDateTime { get; set; }
            public bool FBool { get; set; }
            public string FBoolStr { get; set; }
            
            public ClassForDataSourceWithFilter(int id = 0, string fString1 = "", string fString2 = "", string fString3 = "", long fDateTime = 0, bool fBool = false)
            {
                Id = id;
                FString1 = fString1;
                FString2 = fString2;
                FString3 = fString3;
                FDateTime = new DateTime(fDateTime);
                FBool = fBool;
                FBoolStr = FBool.ToString();
            }

            public ClassForDataSourceWithFilter(ClassForDataSourceWithFilter obj) : this(obj.Id, obj.FString1, obj.FString2, obj.FString3, obj.FDateTime.Ticks, obj.FBool)
            {}
    }

    #endif
}
