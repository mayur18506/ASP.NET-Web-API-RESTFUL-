using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mayur.Models;

namespace Mayur.Controllers
{
    public class Employee41Controller : Controller
    {
        private EmployeeDBEntities db = new EmployeeDBEntities();

        // GET: Employee41
        public ActionResult Index()
        {
            return View(db.Employee4.ToList());
        }

        // GET: Employee41/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee4 employee4 = db.Employee4.Find(id);
            if (employee4 == null)
            {
                return HttpNotFound();
            }
            return View(employee4);
        }

        // GET: Employee41/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee41/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,Name,Gender,Age,Salary,City,Department")] Employee4 employee4)
        {
            if (ModelState.IsValid)
            {
                db.Employee4.Add(employee4);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee4);
        }

        // GET: Employee41/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee4 employee4 = db.Employee4.Find(id);
            if (employee4 == null)
            {
                return HttpNotFound();
            }
            return View(employee4);
        }

        // POST: Employee41/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,Name,Gender,Age,Salary,City,Department")] Employee4 employee4)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee4).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee4);
        }

        // GET: Employee41/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee4 employee4 = db.Employee4.Find(id);
            if (employee4 == null)
            {
                return HttpNotFound();
            }
            return View(employee4);
        }

        // POST: Employee41/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee4 employee4 = db.Employee4.Find(id);
            db.Employee4.Remove(employee4);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
