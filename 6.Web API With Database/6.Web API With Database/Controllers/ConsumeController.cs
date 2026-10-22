using _6.Web_API_With_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace _6.Web_API_With_Database.Controllers
{
    public class ConsumeController : Controller
    {
        // GET: Consume

        HttpClient client = new HttpClient();
        public ActionResult Index()
        {
            List<Employee4> list = new List<Employee4>();
            client.BaseAddress = new Uri("https://localhost:44350/api/NewApi");
            var response = client.GetAsync("NewApi");
            response.Wait();

            var test = response.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Employee4>>();
                display.Wait();
                list = display.Result;
            }

            return View(list);
        }
    }
}