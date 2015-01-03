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
    public class CareerFairsController : Controller
    {
        private CollegeProgramEntities db = new CollegeProgramEntities();

        // GET: CareerFairs
        public ActionResult Index()
        {
            var careerFairs = db.CareerFairs.Include(c => c.Advisor).Include(c => c.Recruiter);
            return View(careerFairs.ToList());
        }

        // GET: CareerFairs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CareerFair careerFair = db.CareerFairs.Find(id);
            if (careerFair == null)
            {
                return HttpNotFound();
            }
            return View(careerFair);
        }

        // GET: CareerFairs/Create
        public ActionResult Create()
        {
            ViewBag.AdvisorID = new SelectList(db.Advisors, "AdvisorID", "AdvisorFirstName");
            ViewBag.RecruiterID = new SelectList(db.Recruiters, "RecruiterID", "Firstname");
            return View();
        }

        // POST: CareerFairs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CareerFairID,Description,Date,Name,LocationName,StreetAddress,City,State,Zip,Sponsor,AdvisorID,RecruiterID")] CareerFair careerFair)
        {
            if (ModelState.IsValid)
            {
                db.CareerFairs.Add(careerFair);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdvisorID = new SelectList(db.Advisors, "AdvisorID", "AdvisorFirstName", careerFair.AdvisorID);
            ViewBag.RecruiterID = new SelectList(db.Recruiters, "RecruiterID", "Firstname", careerFair.RecruiterID);
            return View(careerFair);
        }

        // GET: CareerFairs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CareerFair careerFair = db.CareerFairs.Find(id);
            if (careerFair == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdvisorID = new SelectList(db.Advisors, "AdvisorID", "AdvisorFirstName", careerFair.AdvisorID);
            ViewBag.RecruiterID = new SelectList(db.Recruiters, "RecruiterID", "Firstname", careerFair.RecruiterID);
            return View(careerFair);
        }

        // POST: CareerFairs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CareerFairID,Description,Date,Name,LocationName,StreetAddress,City,State,Zip,Sponsor,AdvisorID,RecruiterID")] CareerFair careerFair)
        {
            if (ModelState.IsValid)
            {
                db.Entry(careerFair).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdvisorID = new SelectList(db.Advisors, "AdvisorID", "AdvisorFirstName", careerFair.AdvisorID);
            ViewBag.RecruiterID = new SelectList(db.Recruiters, "RecruiterID", "Firstname", careerFair.RecruiterID);
            return View(careerFair);
        }

        // GET: CareerFairs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CareerFair careerFair = db.CareerFairs.Find(id);
            if (careerFair == null)
            {
                return HttpNotFound();
            }
            return View(careerFair);
        }

        // POST: CareerFairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            CareerFair careerFair = db.CareerFairs.Find(id);
            db.CareerFairs.Remove(careerFair);
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
