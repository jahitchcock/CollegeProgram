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
    public class JobsController : Controller
    {
        private CollegeProgramEntities db = new CollegeProgramEntities();

        // GET: Jobs
        public ActionResult Index()
        {
            var jobs = db.Jobs.Include(j => j.Advisor).Include(j => j.Company).Include(j => j.Recruiter);
            return View(jobs.ToList());
        }

        // GET: Jobs/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            ViewBag.AdvisorID = new SelectList(db.Advisors, "AdvisorID", "AdvisorFirstName");
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName");
            ViewBag.RecruiterID = new SelectList(db.Recruiters, "RecruiterID", "Firstname");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobId,JobLocation,JobTitle,JobDescription,JobPostingDate,JobDegreeRequirements,SocialMediaProfile,AdvisorID,RecruiterID,CompanyID,PostingDate,DegreeField,Status")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Jobs.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdvisorID = new SelectList(db.Advisors, "AdvisorID", "AdvisorFirstName", job.AdvisorID);
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", job.CompanyID);
            ViewBag.RecruiterID = new SelectList(db.Recruiters, "RecruiterID", "Firstname", job.RecruiterID);
            return View(job);
        }

        // GET: Jobs/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdvisorID = new SelectList(db.Advisors, "AdvisorID", "AdvisorFirstName", job.AdvisorID);
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", job.CompanyID);
            ViewBag.RecruiterID = new SelectList(db.Recruiters, "RecruiterID", "Firstname", job.RecruiterID);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobId,JobLocation,JobTitle,JobDescription,JobPostingDate,JobDegreeRequirements,SocialMediaProfile,AdvisorID,RecruiterID,CompanyID,PostingDate,DegreeField,Status")] Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdvisorID = new SelectList(db.Advisors, "AdvisorID", "AdvisorFirstName", job.AdvisorID);
            ViewBag.CompanyID = new SelectList(db.Companies, "CompanyID", "CompanyName", job.CompanyID);
            ViewBag.RecruiterID = new SelectList(db.Recruiters, "RecruiterID", "Firstname", job.RecruiterID);
            return View(job);
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
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
