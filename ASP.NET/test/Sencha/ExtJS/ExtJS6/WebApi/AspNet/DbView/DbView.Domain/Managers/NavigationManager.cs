using System;
using System.Collections.Generic;
using System.Data;
using DbView.Domain.Interfaces;
using DbView.Domain.Models;
using DbView.Domain.Helpers;

namespace DbView.Domain
{
    public class NavigationManager : INavigation
    {
        public IEnumerable<NavigationItem> GetData()
        {
            const string
                idFieldName = "Id",
                tableNameFieldName = "TableName",
                descriptionFieldName = "Description";

            var result = MsSqlDbHelper.Instance.ExecuteQuery(@"
select
    t.object_id as Id,
	t.name as TableName,
	coalesce(cast(ep.value as sql_variant), t.name) as Description
from
	 sys.tables t
	 left join sys.extended_properties ep on ep.major_id = t.object_id and ep.minor_id = 0;
");
            return result.AsEnumerable().Select(row => new NavigationItem(Convert.ToInt32(row[idFieldName]), Convert.ToString(row[tableNameFieldName]), Convert.ToString(row[descriptionFieldName])));
        }
    }
}
