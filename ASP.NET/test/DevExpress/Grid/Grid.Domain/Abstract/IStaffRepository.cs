using System.Linq;
using Grid.Domain.Database;

namespace Grid.Domain.Abstract
{
    public interface IStaffRepository
    {
        IQueryable<Staff> Staffs { get; }
    }
}
