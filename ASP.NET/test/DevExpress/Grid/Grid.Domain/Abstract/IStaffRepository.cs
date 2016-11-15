using System.Linq;
using Grid.Domain.Entities;

namespace Grid.Domain.Abstract
{
    public interface IStaffRepository
    {
        IQueryable<Staff> Staffs { get; }
    }
}
