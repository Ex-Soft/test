using System.Collections.Generic;
using DbView.Domain.Models;

namespace DbView.Domain.Interfaces
{
    public interface INavigation
    {
        IEnumerable<NavigationItem> GetData();
    }
}
