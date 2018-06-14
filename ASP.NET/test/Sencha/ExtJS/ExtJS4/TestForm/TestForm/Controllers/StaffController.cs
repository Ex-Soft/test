// https://stackoverflow.com/questions/10937524/how-should-i-pass-multiple-parameters-to-an-asp-net-web-api-get

using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TestForm.Models;

namespace TestForm.Controllers
{
    public class StaffController : ApiController
    {
        [HttpGet]
        public StaffResponse Staffs([FromUri] StaffRequest request)
        {
            var result = new StaffResponse();

            result.rows = GetData().Skip(request.start).Take(request.limit).Select(item => item).ToList();
            result.total = result.rows.Count;
            result.success = true;

            return result;
        }

        IEnumerable<Staff> GetData()
        {
            return Enumerable.Range(1, 5).Select(i => new Staff { id = i, name = $"Record# {i}" });
        }
    }
}
