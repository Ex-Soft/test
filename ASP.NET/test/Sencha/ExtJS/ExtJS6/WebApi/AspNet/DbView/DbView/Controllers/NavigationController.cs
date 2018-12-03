using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DbView.Models;
using DbView.Domain;
using DbView.Domain.Interfaces;

namespace DbView.Controllers
{
    public class NavigationController : ApiController
    {
        private INavigation _navigationManager;

        public NavigationController()
        {
            _navigationManager = new NavigationManager();
        }

        [HttpGet]
        public object Get([FromUri] GetRequestParams requestParams)
        {
            var data = GetData();

            if (!requestParams.needMetadata)
                return new { success = true, total = data.Count, rows = data };
            
            var metadata = GetMetadata();
            return new { success = true, total = data.Count, rows = data, metaData = metadata };
        }

        private ICollection<NavigationItem> GetData()
        {
            return _navigationManager.GetData().Select(item => new NavigationItem(item.Id, item.Name, item.Description)).ToArray();
        }

        private object GetMetadata()
        {
            return new { root = "rows", clientIdProperty = "id", fields = GetFields(), columns = GetColumns() };
        }

        private object GetFields()
        {
            return new object[] {
                new { name = "id", type = "int" },
                new { name = "name", type = "string" },
                new { name = "description", type = "string" }
            };
        }

        private object GetColumns()
        {
            return new object[] {
                new { dataIndex = "description", header = "Table", flex = 1, align = "left" }
            };
        }
    }
}
