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
    public class CareerPlansController : Controller
    {
        private CollegeProgramEntities db = new CollegeProgramEntities();

        // GET: CareerPlans
        public ActionResult Index()
        {
            var careerPlans = db.CareerPlans.Include(c => c.Advisor).Include(c => c.Student);
            return View(careerPlans.ToList());
        }

        // GET: CareerPlans/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CareerPlan careerPlan = db.CareerPlans.Find(id);
            if (careerPlan == null)
            {
                return HttpNotFound();
            }
            return View(careerPlan);
        }

        // GET: CareerPlans/Create
        public ActionResult Create()
        {
            ViewBag.AdvisorID = new SelectList(db.Advisors, "AdvisorID", "AdvisorFirstName");
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName");
            return View();
        }

        // POST: CareerPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CareerPlanID,StudentID,AdvisorID,RecruiterID,Resume,AdvisorCareerForecast,RecruiterCareerForecast,StudentCareerGoals,JobLocationState")] CareerPlan careerPlan)
        {
            if (ModelState.IsValid)
            {
                db.CareerPlans.Add(careerPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdvisorID = new SelectList(db.Advisors, "AdvisorID", "AdvisorFirstName", careerPlan.AdvisorID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", careerPlan.StudentID);
            return View(careerPlan);
        }

        // GET: CareerPlans/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CareerPlan careerPlan = db.CareerPlans.Find(id);
            if (careerPlan == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdvisorID = new SelectList(db.Advisors, "AdvisorID", "AdvisorFirstName", careerPlan.AdvisorID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", careerPlan.StudentID);
            return View(careerPlan);
        }

        // POST: CareerPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CareerPlanID,StudentID,AdvisorID,RecruiterID,Resume,AdvisorCareerForecast,RecruiterCareerForecast,StudentCareerGoals,JobLocationState")] CareerPlan careerPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(careerPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdvisorID = new SelectList(db.Advisors, "AdvisorID", "AdvisorFirstName", careerPlan.AdvisorID);
            ViewBag.StudentID = new SelectList(db.Students, "StudentID", "FirstName", careerPlan.StudentID);
            return View(careerPlan);
        }

        // GET: CareerPlans/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CareerPlan careerPlan = db.CareerPlans.Find(id);
            if (careerPlan == null)
            {
                return HttpNotFound();
            }
            return View(careerPlan);
        }

        // POST: CareerPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CareerPlan careerPlan = db.CareerPlans.Find(id);
            db.CareerPlans.Remove(careerPlan);
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
