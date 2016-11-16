using System.Linq;
using Grid.Domain.Abstract;
using Grid.Domain.Database;

namespace Grid.Domain.Concrete
{
    public class EFStaffRepository : IStaffRepository
    {
        private testlocaldbEntities context = new testlocaldbEntities();

        public IQueryable<Staff> Staffs
        {
            get { return context.Staff; }
        } 
    }
}
