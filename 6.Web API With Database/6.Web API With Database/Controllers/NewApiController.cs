using _6.Web_API_With_Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _6.Web_API_With_Database.Controllers
{
    public class NewApiController : ApiController
    {
        EmployeeDBEntities db = new EmployeeDBEntities();

        [HttpGet]
        public IHttpActionResult Index()
        {
            List<Employee4> obj = db.Employee4.ToList();
            return Ok(obj);
        }

        [HttpGet]
        public IHttpActionResult Index(int id)
        {
            var obj = db.Employee4.Where(model => model.EmployeeId == id).FirstOrDefault();
            return Ok(obj);
        }
    }
}
