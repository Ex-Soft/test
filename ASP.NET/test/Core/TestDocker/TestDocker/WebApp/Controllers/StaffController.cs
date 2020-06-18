using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class StaffController : Controller
    {
        private static readonly HttpClient HttpClient;

        private readonly Uri _uri;

        static StaffController()
        {
            HttpClient = new HttpClient();
        }

        public StaffController(IDbServiceSettings dbServiceSettings)
        {
            _uri = new Uri(new Uri(dbServiceSettings.BaseAddress), new Uri(!dbServiceSettings.Api.EndsWith("/") ? $"{dbServiceSettings.Api}/" : dbServiceSettings.Api, UriKind.Relative));
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await HttpClient.GetAsync(_uri);

            if (result.IsSuccessStatusCode)
            {
                return View(JsonConvert.DeserializeObject<List<Staff>>(await result.Content.ReadAsStringAsync()));
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Staff staff)
        {
            if (staff == null)
                return NotFound();

            var response = await HttpClient.PostAsync(_uri, new StringContent(JsonConvert.SerializeObject(staff), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            var staffCreated = JsonConvert.DeserializeObject<Staff>(await response.Content.ReadAsStringAsync());

            return Created($"/{ControllerContext.ActionDescriptor.ControllerName}/{staffCreated.Id}", staffCreated);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return NotFound();

            var response = await HttpClient.DeleteAsync(new Uri(_uri, id));

            if (response.StatusCode != HttpStatusCode.NoContent)
                return NotFound();

            return Ok();
        }

        [HttpGet]
        public string GetIP()
        {
            return $"{GetIP(Dns.GetHostName())};{GetIP("webapp")};{GetIP("dbservice")};{GetIP("mongo")}";
        }

        private string GetIP(string hostName)
        {
            var ips = Dns.GetHostAddresses(hostName);
            return $"{hostName};{string.Join(';', ips.Select(ip => ip.ToString()))}";
        }
    }
}
