using System.Collections.Generic;
using System.Web.Http;
using Grid.Domain.Abstract;
using Grid.Domain.Concrete;
using Grid.Domain.Database;

namespace BackEnd.Controllers
{
    public class StaffsController : ApiController
    {
        private readonly IStaffRepository _staffRepository = new EFStaffRepository();

        public IEnumerable<Staff> GetAllStaffs()
        {
            return _staffRepository.Staffs;
        } 
    }
}
