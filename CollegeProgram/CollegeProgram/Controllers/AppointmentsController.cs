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
    public class AppointmentsController : Controller
    {
        private CollegeProgramEntities db = new CollegeProgramEntities();

        // GET: Appointments
        public ActionResult Index()
        {
            var appointments = db.Appointments.Include(a => a.Advisor).Include(a => a.Student);
            return View(appointments.ToList());
        }

        // GET: Appointments/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointments/Create
        public ActionResult Create()
        {
            ViewBag.AdvisorID = new SelectList(db.Advisors, "AdvisorID", "AdvisorFirstName");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppointmentID,StudentID,AdvisorID,ApointmentDate,ApointmentTime,AppointmentType,AppointmentLocation")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Appointments.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdvisorID = new SelectList(db.Advisors, "AdvisorID", "AdvisorFirstName", appointment.AdvisorID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", appointment.StudentID);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdvisorID = new SelectList(db.Advisors, "AdvisorID", "AdvisorFirstName", appointment.AdvisorID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", appointment.StudentID);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppointmentID,StudentID,AdvisorID,ApointmentDate,ApointmentTime,AppointmentType,AppointmentLocation")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdvisorID = new SelectList(db.Advisors, "AdvisorID", "AdvisorFirstName", appointment.AdvisorID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", appointment.StudentID);
            return View(appointment);
        }

        // GET: Appointments/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
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
