using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _4.Create_Web_API.Controllers
{
    public class EmployeesDataController : ApiController
    {
        public string[] myEmployees = { "Mayur", "Aman", "Kunal" };

        [HttpGet]
        public string[] GetEmployees()
        {
            return myEmployees;
        }

        [HttpGet]
        public string GetEmployeeByIndex(int id)  //parameter always id.
        {
            return myEmployees[id];
        }
    }
}
