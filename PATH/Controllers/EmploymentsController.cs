using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ProvalusApplicantTrackingHub.Models;
using ProvalusApplicantTrackingHub.Repository;
using Dropbox.Api;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Dropbox.Api.Files;
using System;
using System.Web;

namespace ProvalusApplicantTrackingHub.Controllers
{
    public class EmploymentsController : Controller
    {
        private IPathRepository repo = new PathRepository();
        private const string token = "ecVOFh0tBNAAAAAAAAAALFgdG5WPVT8PJqdfXrT4Jk5GugJqfEDwLcjP9381jup-";

        // GET: Employments


        public async Task<ActionResult> Index(int jaid)
        {


            TempData["jaid"] = jaid;
            var jobApp = repo.GetJobAppById(jaid);
            var empVM = new EmploymentViewModel()
            {

                JAID = jaid,
                NewEmp = new Employment(),
                Employments = repo.GetEmploymentsByJobAppId(jaid),
                Address = new Address() { JobApp = jobApp }

            };
            //use in other places
            TempData["jaid"] = jaid;

            if(empVM.Employments.Count <= 0 && !string.IsNullOrEmpty(jobApp.Resume))
            {
                string ext = Path.GetExtension(jobApp.Resume);

                string filename = jobApp.Resume.TrimEnd(ext.ToCharArray());

                //Replaces the "+" with a space.  This allows the app to pull the filename when populating the web address for each resume'
                filename = filename.Replace('+', ' ');
                
                //Same as the JobApps Controller.
                //Pulls the information needed from the txt file on Dropbox to populate the information on the Employment section of the Application
                DropboxClient dpc = new DropboxClient(token);
                var e = await dpc.Files.DownloadAsync("/Parsed Resumes/" + filename + ".txt").Result.GetContentAsStringAsync();



                var emp = new Employment();
                emp.JobApp = jobApp;
                emp.Address.JobApp = jobApp;
                emp.Address.Type = AddressType.Employer;

                JsonConvert.PopulateObject(e, emp);
                repo.CreateEmployment(emp);
                empVM.Employments.Add(emp);
            }

            return View(empVM);


        }


        // GET: Employments/Details/5
        public ActionResult Details(int? id, int jaid)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employment employment = repo.GetEmploymentById(id ?? 0);
            if (employment == null)
            {
                return HttpNotFound();
            }
            TempData["jaid"] = jaid;
            return View(employment);
        }

        // GET: Employments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Employments,Address", Include = "JAID,NewEmp")] EmploymentViewModel employmentVM)
        {
            if (ModelState.IsValid)
            {
                var jobApp = repo.GetJobAppById(employmentVM.JAID);
                employmentVM.NewEmp.JobApp = jobApp;
                repo.CreateEmployment(employmentVM.NewEmp);
                TempData["jaid"] = employmentVM.JAID;
                return RedirectToAction("Index", new { jaid = employmentVM.JAID });
            }
            TempData["jaid"] = employmentVM.JAID;
            return RedirectToAction("Index");
        }

        // GET: Employments/Edit/5
        public ActionResult Edit(int? id, int jaid)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employment employment = repo.GetEmploymentById(id ?? 0);
            if (employment == null)
            {
                return HttpNotFound();
            }
            TempData["jaid"] = jaid;
            return View(employment);
        }

        // POST: Employments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Current,Employer,JobTitle,EmployerPhone,StartPay,PayRate,PayRateID,EndPay,StartDate,EndDate")] Employment employment, int jaid)
        {
            if (ModelState.IsValid)
            {
                repo.UpdateEmployment(employment);
                TempData["jaid"] = jaid;
                return RedirectToAction("Index", new { jaid = jaid});
            }
            TempData["jaid"] = jaid;
            return View(employment);
        }

        // GET: Employments/Delete/5
        public ActionResult Delete(int? id, int jaid)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employment employment = repo.GetEmploymentById(id ?? 0);
            if (employment == null)
            {
                return HttpNotFound();
            }
            TempData["jaid"] = jaid;
            return View(employment);
        }

        // POST: Employments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int jaid)
        {
            repo.DeleteEmployment(id);
            TempData["jaid"] = jaid;
            return RedirectToAction("Index", new { jaid = jaid });
        }



        //    //protected override void Dispose(bool disposing)
        //    //{
        //    //    if (disposing)
        //    //    {
        //    //        db.Dispose();
        //    //    }
        //    //    base.Dispose(disposing);
        //    //}
    }

}

