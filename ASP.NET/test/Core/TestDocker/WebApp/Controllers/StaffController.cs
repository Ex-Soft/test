using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class StaffController : Controller
    {
        private static readonly HttpClient _httpClient;

        private readonly IDbServiceSettings _dbServiceSettings;

        static StaffController()
        {
            _httpClient = new HttpClient();
        }

        public StaffController(IDbServiceSettings dbServiceSettings)
        {
            _dbServiceSettings = dbServiceSettings;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _httpClient.GetAsync(new Uri($"{_dbServiceSettings.BaseAddress}{_dbServiceSettings.Api}"));

            if (result.IsSuccessStatusCode)
            {
                return View(JsonConvert.DeserializeObject<List<Staff>>(await result.Content.ReadAsStringAsync()));
            }

            return BadRequest();
        }
    }
}
