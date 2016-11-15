using System.Linq;
using Grid.Domain.Abstract;
using Grid.Domain.Entities;

namespace Grid.Domain.Concrete
{
    public class EFStaffRepository : IStaffRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Staff> Staffs
        {
            get { return context.Staffs; }
        } 
    }
}
