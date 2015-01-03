using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CollegeProgram.Models;

namespace CollegeProgram.Controllers
{
    public class StudentAvailabilitiesController : Controller
    {
        private CollegeProgramEntities db = new CollegeProgramEntities();

        // GET: StudentAvailabilities
        public ActionResult Index()
        {
            var studentAvailabilities = db.StudentAvailabilities.Include(s => s.Student);
            return View(studentAvailabilities.ToList());
        }

        // GET: StudentAvailabilities/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAvailability studentAvailability = db.StudentAvailabilities.Find(id);
            if (studentAvailability == null)
            {
                return HttpNotFound();
            }
            return View(studentAvailability);
        }

        // GET: StudentAvailabilities/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName");
            return View();
        }

        // POST: StudentAvailabilities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AvailabilityID,StudentID,BeginTime,EndTime,Sun,Mon,Tue,Wed,Thu,Fri,Sat,BeginDate,EndDate")] StudentAvailability studentAvailability)
        {
            if (ModelState.IsValid)
            {
                db.StudentAvailabilities.Add(studentAvailability);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", studentAvailability.StudentID);
            return View(studentAvailability);
        }

        // GET: StudentAvailabilities/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAvailability studentAvailability = db.StudentAvailabilities.Find(id);
            if (studentAvailability == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", studentAvailability.StudentID);
            return View(studentAvailability);
        }

        // POST: StudentAvailabilities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AvailabilityID,StudentID,BeginTime,EndTime,Sun,Mon,Tue,Wed,Thu,Fri,Sat,BeginDate,EndDate")] StudentAvailability studentAvailability)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentAvailability).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", studentAvailability.StudentID);
            return View(studentAvailability);
        }

        // GET: StudentAvailabilities/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentAvailability studentAvailability = db.StudentAvailabilities.Find(id);
            if (studentAvailability == null)
            {
                return HttpNotFound();
            }
            return View(studentAvailability);
        }

        // POST: StudentAvailabilities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            StudentAvailability studentAvailability = db.StudentAvailabilities.Find(id);
            db.StudentAvailabilities.Remove(studentAvailability);
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
