// https://stackoverflow.com/questions/10937524/how-should-i-pass-multiple-parameters-to-an-asp-net-web-api-get

using System.Collections.Generic;
using System.Web.Http;
using TestForm.Models;

namespace TestForm.Controllers
{
    public class FormController : ApiController
    {
        [HttpPost]
        public FormResponse Load([FromBody] FormRequest request)
        {
            return new FormResponse() { success = true, data = new Dictionary<string, object> { { "TextField", "TextField" } } };
        }
    }
}
