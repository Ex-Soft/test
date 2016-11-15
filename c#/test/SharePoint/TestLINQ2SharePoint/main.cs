using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;

namespace TestLINQ2SharePoint
{
    class Program
    {
        static void Main(string[] args)
        {
            const string
                requestUrl = "http://nozhenko-s8k/",
                SPWeb = "DocNet",
                SPListName = "Внутрішні документи", //"Задачі", //"TaskReports",
                FieldNameId = "dn_ct_TaskId",
                FieldNameInfo = "dn_ct_TaskReportInfo";

            using (SPSite spSite = new SPSite(requestUrl))
            {
                using(DataContext dataContext=new DataContext(requestUrl))
                {
                    Entity
                }
            }
        }
    }
}
