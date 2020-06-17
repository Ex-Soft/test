using System;
using System.Collections.Generic;
using System.IO;
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

            var result = await HttpClient.GetAsync(_uri);

            if (result.IsSuccessStatusCode)
            {
                return View("Index",JsonConvert.DeserializeObject<List<Staff>>(await result.Content.ReadAsStringAsync()));
            }

            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return BadRequest();

            var response = await HttpClient.DeleteAsync(new Uri(_uri, id));

            if (response.StatusCode != HttpStatusCode.NoContent)
                return BadRequest();

            var result = await HttpClient.GetAsync(_uri);

            if (result.IsSuccessStatusCode)
            {
                return View("Index", JsonConvert.DeserializeObject<List<Staff>>(await result.Content.ReadAsStringAsync()));
            }

            return BadRequest();
        }
    }
}
