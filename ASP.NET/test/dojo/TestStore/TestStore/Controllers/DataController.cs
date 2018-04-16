using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestStore.Models;

namespace TestStore.Controllers
{
    public class DataController : ApiController
    {
        Data[] data =
        {
            new Data{Id = 1, FString = "FString# 1", FDecimal = 1m, FDateTime = new DateTime(2018, 4, 13, 13, 13, 13)},
            new Data{Id = 2, FString = "FString# 2", FDecimal = 2m, FDateTime = new DateTime(2018, 4, 13, 13, 13, 13)},
            new Data{Id = 3, FString = "FString# 3", FDecimal = 3m, FDateTime = new DateTime(2018, 4, 13, 13, 13, 13)},
        };

        public HttpResponseMessage GetAllData()
        {
            return Request.CreateResponse(HttpStatusCode.OK, data);
            //return Request.CreateResponse(HttpStatusCode.InternalServerError, "blah-blah-blah");
        }

        public IHttpActionResult GetData(int id)
        {
            var item = data.FirstOrDefault((p) => p.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}
