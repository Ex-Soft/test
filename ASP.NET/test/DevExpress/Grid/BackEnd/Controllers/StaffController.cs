using System.Collections.Generic;
using System.Web.Http;
using Grid.Domain.Abstract;
using Grid.Domain.Concrete;
using Grid.Domain.Entities;

namespace BackEnd.Controllers
{
    public class StaffController : ApiController
    {
        IStaffRepository staffRepository = new EFStaffRepository();
        public IEnumerable<Staff> GetAllStaffs()
        {
            return staffRepository.Staffs;
        } 
    }
}
