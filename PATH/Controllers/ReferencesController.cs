using ProvalusApplicantTrackingHub.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProvalusApplicantTrackingHub.Models;
using System.Threading.Tasks;
using Dropbox.Api;
using Dropbox.Api.Files;
using Newtonsoft.Json;
using System.IO;

namespace ProvalusApplicantTrackingHub.Controllers
{
    public class ReferencesController : Controller
    {
        private IPathRepository repo = new PathRepository();
        private const string token = "ecVOFh0tBNAAAAAAAAAALFgdG5WPVT8PJqdfXrT4Jk5GugJqfEDwLcjP9381jup-";


        // GET: References
        public ActionResult Index(int jaid)
        {
            TempData["jaid"] = jaid;
            var jobApp = repo.GetJobAppById(jaid);
            List<Reference> refs = repo.GetReferencesByJobAppId(jaid);
           

            //DropboxClient dpc = new DropboxClient(token);
            //var e = await dpc.Files.DownloadAsync("/Parsed Resumes/" + jobApp.Resume + ".txt").Result.GetContentAsStringAsync();

            //var newRef = new Reference();
            //newRef.JobApp = jobApp;

            //JsonConvert.PopulateObject(e, newRef);
            ////repo.CreateEmployment(emp);

            //refs.Add(newRef);
            //////emp.Address = adrs;
            
            return View(refs);
        }


        // GET: References/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reference reference = repo.GetReferenceById(id ?? 0);
            if (reference == null)
            {
                return HttpNotFound();
            }
            return View(reference);
        }

        // GET: References/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: References/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Title,Company,Phone")] Reference reference)
        {
            if (ModelState.IsValid)
            {
                repo.CreateReference(reference);
                return RedirectToAction("Index");
            }

            return View(reference);
        }

        // GET: References/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reference reference = repo.GetReferenceById(id ?? 0);
            if (reference == null)
            {
                return HttpNotFound();
            }
            return View(reference);
        }

        // POST: References/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Title,Company,Phone")] Reference reference)
        {
            if (ModelState.IsValid)
            {
                repo.UpdateReference(reference);
                return RedirectToAction("Index");
            }
            return View(reference);
        }

        // GET: References/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reference reference = repo.GetReferenceById(id ?? 0);
            if (reference == null)
            {
                return HttpNotFound();
            }
            return View(reference);
        }

        // POST: References/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repo.DeleteReference(id);
            return RedirectToAction("Index");
        }



    }
}
