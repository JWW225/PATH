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
    public class TechnologiesController : Controller
    {
        private IPathRepository repo = new PathRepository();

        // GET: Technologies
        public ActionResult Index()
        {
            
            return View(repo.GetAllTechnologies());
        }

        // GET: Technologies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Technology technology = repo.GetTechnologyById(id ?? 0);
            if (technology == null)
            {
                return HttpNotFound();
            }
            return View(technology);
        }

        // GET: Technologies/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Technologies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Position")] Technology technology)
        {
            if (ModelState.IsValid)
            {
                repo.CreateTechnology(technology);
                return RedirectToAction("Index");
            }

            return View(technology);
        }

        // GET: Technologies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Technology technology = repo.GetTechnologyById(id ?? 0);
            if (technology == null)
            {
                return HttpNotFound();
            }
            return View(technology);
        }


        // POST: Technologies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Position")] Technology technology)
        {
            if (ModelState.IsValid)
            {
                repo.UpdateTechnology(technology);
                return RedirectToAction("Index");
            }
            return View(technology);
        }

        // GET: Technologies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Technology technology = repo.GetTechnologyById(id ?? 0);
            if (technology == null)
            {
                return HttpNotFound();
            }
            return View(technology);
        }

        // POST: Technologies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.DeleteTechnology(id);
            return RedirectToAction("Index");
        }


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
