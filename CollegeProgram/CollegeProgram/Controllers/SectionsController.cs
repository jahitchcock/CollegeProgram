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
    public class SectionsController : Controller
    {
        private CollegeProgramEntities db = new CollegeProgramEntities();

        // GET: Sections
        public ActionResult Index()
        {
            var sections = db.Sections.Include(s => s.Course).Include(s => s.Instructor).Include(s => s.Room).Include(s => s.Term);
            return View(sections.ToList());
        }

        // GET: Sections/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = db.Sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // GET: Sections/Create
        public ActionResult Create()
        {
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Name");
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "FirstName");
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "Description");
            ViewBag.TermID = new SelectList(db.Terms, "TermID", "Year");
            return View();
        }

        // POST: Sections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SectionID,Day,StartTime,EndTime,StartDate,EndDate,TermID,CourseID,RoomID,InstructorID")] Section section)
        {
            if (ModelState.IsValid)
            {
                db.Sections.Add(section);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Name", section.CourseID);
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "FirstName", section.InstructorID);
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "Description", section.RoomID);
            ViewBag.TermID = new SelectList(db.Terms, "TermID", "Year", section.TermID);
            return View(section);
        }

        // GET: Sections/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = db.Sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Name", section.CourseID);
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "FirstName", section.InstructorID);
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "Description", section.RoomID);
            ViewBag.TermID = new SelectList(db.Terms, "TermID", "Year", section.TermID);
            return View(section);
        }

        // POST: Sections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SectionID,Day,StartTime,EndTime,StartDate,EndDate,TermID,CourseID,RoomID,InstructorID")] Section section)
        {
            if (ModelState.IsValid)
            {
                db.Entry(section).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CourseID = new SelectList(db.Courses, "CourseID", "Name", section.CourseID);
            ViewBag.InstructorID = new SelectList(db.Instructors, "InstructorID", "FirstName", section.InstructorID);
            ViewBag.RoomID = new SelectList(db.Rooms, "RoomID", "Description", section.RoomID);
            ViewBag.TermID = new SelectList(db.Terms, "TermID", "Year", section.TermID);
            return View(section);
        }

        // GET: Sections/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = db.Sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(section);
        }

        // POST: Sections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Section section = db.Sections.Find(id);
            db.Sections.Remove(section);
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
