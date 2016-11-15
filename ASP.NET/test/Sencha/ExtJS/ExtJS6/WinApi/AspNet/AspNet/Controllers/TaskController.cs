using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Script.Services;
using AspNet.Models;

namespace AspNet.Controllers
{
    public class TaskController : ApiController
    {
        Task[] tasks;

        public TaskController()
        {
            const int count = 100;

            var listOfTask = new List<Task>(count);

            var date = DateTime.Now.Date.AddDays(-1);

            TimeSpan
                begin = new TimeSpan(0, 0, 0, 0, 0),
                delta = new TimeSpan(0, 0, 20, 0, 0);

            for (int i = 1, j = 1; i <= count; ++i, ++j)
            {
                if (j > 25)
                {
                    j = 1;
                    date = date.AddDays(1);
                    begin = new TimeSpan(0, 0, 0, 0, 0);
                }

                listOfTask.Add(new Task {Id = i, TaskName = $"#{i} {date} #{j}", Date = date, Begin = date + begin, End = date + begin + delta });

                begin = begin.Add(delta);
            }

            tasks = listOfTask.ToArray();
        }

        //[HttpGet]
        //[Route("task")]
        //public IHttpActionResult Get(ulong _dc, DateTime date, int page, int start, int limit)
        //{
        //    var taskOnDate = tasks.Where(t => t.Date.Date == date.Date).ToArray();
        //    return Json(new TaskResponse { data = taskOnDate.Skip(start).Take(limit).Select(t => t).ToArray(), message = "message", success = true, total = taskOnDate.Length });
        //}

        // Without
        // config.Formatters.Clear();
        // config.Formatters.Add(new JsonMediaTypeFormatter());
        // in WebApiConfig.cs
        // for
        // Accept text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8
        // in Headers (FF)
        // returns XML
        [HttpGet]
        [Route("task")]
        public TaskResponse Get(ulong _dc, DateTime date, int page, int start, int limit)
        {
            var taskOnDate = tasks.Where(t => t.Date.Date == date.Date).ToArray();
            return new TaskResponse { data = taskOnDate.Skip(start).Take(limit).Select(t => t).ToArray(), message = "message", success = true, total = taskOnDate.Length };
        }

        public IHttpActionResult Get(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }
    }

    public class TaskRequest
    {
        public ulong? _dc { get; set; }
        public int page { get; set; }
        public int start { get; set; }
        public int limit { get; set; }
    }

    public class TaskResponse
    {
        public bool success { get; set; }
        public int total { get; set; }
        public string message { get; set; }
        public Task[] data { get; set; }
    }
}
