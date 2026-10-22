using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Mayur.Models;

namespace Mayur.Controllers
{
    public class Employee4Controller : ApiController
    {
        private EmployeeDBEntities db = new EmployeeDBEntities();

        // GET: api/Employee4
        public IQueryable<Employee4> GetEmployee4()
        {
            return db.Employee4;
        }

        // GET: api/Employee4/5
        [ResponseType(typeof(Employee4))]
        public IHttpActionResult GetEmployee4(int id)
        {
            Employee4 employee4 = db.Employee4.Find(id);
            if (employee4 == null)
            {
                return NotFound();
            }

            return Ok(employee4);
        }

        // PUT: api/Employee4/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee4(int id, Employee4 employee4)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee4.EmployeeId)
            {
                return BadRequest();
            }

            db.Entry(employee4).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Employee4Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Employee4
        [ResponseType(typeof(Employee4))]
        public IHttpActionResult PostEmployee4(Employee4 employee4)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Employee4.Add(employee4);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee4.EmployeeId }, employee4);
        }

        // DELETE: api/Employee4/5
        [ResponseType(typeof(Employee4))]
        public IHttpActionResult DeleteEmployee4(int id)
        {
            Employee4 employee4 = db.Employee4.Find(id);
            if (employee4 == null)
            {
                return NotFound();
            }

            db.Employee4.Remove(employee4);
            db.SaveChanges();

            return Ok(employee4);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Employee4Exists(int id)
        {
            return db.Employee4.Count(e => e.EmployeeId == id) > 0;
        }
    }
}