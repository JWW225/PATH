using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProvalusApplicantTrackingHub.Models;
using ProvalusApplicantTrackingHub.Repository;

namespace ProvalusApplicantTrackingHub.Controllers
{
    public class EducationsController : Controller
    {
        private IPathRepository repo = new PathRepository();

        // GET: Educations
        public ActionResult Index(int jaid)
        {
            TempData["jaid"] = jaid;
            var eduVM = new EducationViewModel()
            {
                JAID = jaid,
                NewEducation = new Education(),
                Educations = repo.GetEducationsByJobAppId(jaid).Count > 0 ? repo.GetEducationsByJobAppId(jaid) : new List<Education>() { new Education() }
            };
            return View(eduVM);
        }

        // GET: Educations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education education = repo.GetEducationById(id ?? 0);
            if (education == null)
            {
                return HttpNotFound();
            }
            return View(education);
        }

        // GET: Educations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Educations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JAID,NewEducation,Educations")] EducationViewModel educationVM)
        {
            if (ModelState.IsValid)
            {
                educationVM.NewEducation.JobApp = repo.GetJobAppById(educationVM.JAID);
                repo.CreateEducation(educationVM.NewEducation);
                return RedirectToAction("Index",new { jaid = educationVM.JAID });
            }

            return View(educationVM);
        }

        // GET: Educations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education education = repo.GetEducationById(id ?? 0);
            if (education == null)
            {
                return HttpNotFound();
            }
            return View(education);
        }

        // POST: Educations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,School,StartDate,EndDate,Major,Degree")] Education education)
        {
            if (ModelState.IsValid)
            {
                repo.UpdateEducation(education);
                return RedirectToAction("Index");
            }
            return View(education);
        }

        // GET: Educations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Education education = repo.GetEducationById(id ?? 0);
            if (education == null)
            {
                return HttpNotFound();
            }
            return View(education);
        }

        // POST: Educations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.DeleteEducation(id);
            return RedirectToAction("Index");
        }

        /* Pending removal (correlating method needed in repo?) */
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
