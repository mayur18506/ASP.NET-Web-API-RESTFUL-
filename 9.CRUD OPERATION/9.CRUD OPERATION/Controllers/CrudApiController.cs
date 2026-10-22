using _9.CRUD_OPERATION.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace _9.CRUD_OPERATION.Controllers
{
    public class CrudApiController : ApiController
    {
        web_api_crud_dbEntities db = new web_api_crud_dbEntities();

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEmployees()
        {
            List<Employee> list = db.Employees.ToList();
            return Ok(list);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetEmployeeById(int id)
        {
            var emp = db.Employees.Where(model => model.ID == id).FirstOrDefault();
            return Ok(emp);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult EmpInsert(Employee e)
        {
            db.Employees.Add(e);
            db.SaveChanges();
            return Ok();
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult EmpUpdate(Employee e)
        {
            //var emp = db.Employees.Where(model => model.ID == e.ID).FirstOrDefault();
            //if (emp != null)
            //{
            //    emp.ID = e.ID;
            //    emp.NAME = e.NAME;
            //    emp.GENDER = e.GENDER;
            //    emp.AGE = e.AGE;
            //    emp.DESIGNATION = e.DESIGNATION;
            //    emp.SALARY = e.SALARY;
            //    db.SaveChanges();
            //}
            //else
            //{
            //    return NotFound();
            //}

            db.Entry(e).State = EntityState.Modified;
            db.SaveChanges();

            return Ok();
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult EmpDelete(int id)
        {
            var emp = db.Employees.Where(model => model.ID == id).FirstOrDefault();
            db.Entry(emp).State = EntityState.Deleted;
            db.SaveChanges();
            return Ok();
        }
    }
}
