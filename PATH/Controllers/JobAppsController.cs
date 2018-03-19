using System;
using ProvalusApplicantTrackingHub.Repository;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ProvalusApplicantTrackingHub.Models;
using Microsoft.AspNet.Identity;
using Dropbox.Api;
using Dropbox.Api.Files;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Web;
using System.IO;
using System.Text;

namespace ProvalusApplicantTrackingHub.Controllers
{
    public class JobAppsController : Controller
    {
        private IPathRepository repo = new PathRepository();
        private const string token = "ecVOFh0tBNAAAAAAAAAALFgdG5WPVT8PJqdfXrT4Jk5GugJqfEDwLcjP9381jup-";
        #region HiddenCode
       
        // GET: JobApps
        public ActionResult Index()
        {
            return View(repo.GetAllJobApps());
        }

        // GET: JobApps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobApp jobApp = repo.GetJobAppById(id ?? 0);
            if (jobApp == null)
            {
                return HttpNotFound();
            }
            return View(jobApp);
        }

        // GET: JobApps/Create
        public ActionResult Create(JobApp jobApp)
        {
            return View(jobApp);
        }

        // POST: JobApps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateNew([Bind(Exclude = "Assignment, Signature, Id, Applicant", Include = "Position,FName,LName,MName,SSN,DOB,Email,PrimaryPhone,PPhoneIsMobile,SecondaryPhone,SPhoneIsMobile,CanRelocate,DateAvailable,DateEntered,AuthorizedToWork,DrugScreen,Military,MilBranch,Conviction,Explanation,Resume,CPABScore,PTScore,Status,Source,EmployeeType,LastEdit,Branch,About")] JobApp jobApp)
        {
            if (ModelState.IsValid)
            {
                jobApp.Applicant = repo.GetCurrentAppUser(User.Identity.GetUserId());
                repo.CreateJobApp(jobApp);
                TempData["jaid"] = jobApp.Id;
                Session["jaid"] = jobApp.Id;
                return RedirectToAction("Index", "Employments", new { jaid = jobApp.Id });
            }

            return View(jobApp);
        }

        // GET: JobApps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobApp jobApp = repo.GetJobAppById(id ?? 0);
            if (jobApp == null)
            {
                return HttpNotFound();
            }
            return View(jobApp);
        }

        // POST: JobApps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Position,FName,LName,MName,SSN,DOB,Email,PrimaryPhone,PPhoneIsMobile,SecondaryPhone,SPhoneIsMobile,CanRelocate,DateAvailable,DateEntered,AuthorizedToWork,DrugScreen,Military,Branch,Conviction,Explanation,Signature,About,Resume,CPABScore,PTScore,Assignment,Status,Source,EmployeeType,LastEdit,Branch")] JobApp jobApp)
        {
            if (ModelState.IsValid)
            {
                repo.UpdateJobApp(jobApp);
                return RedirectToAction("Index");
            }
            return View(jobApp);
        }

        // GET: JobApps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobApp jobApp = repo.GetJobAppById(id ?? 0);
            if (jobApp == null)
            {
                return HttpNotFound();
            }
            return View(jobApp);
        }

        // POST: JobApps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobApp jobApp = repo.GetJobAppById(id);
            repo.DeleteJobApp(id);
            return RedirectToAction("Index");
        }

        public ActionResult Confirmation()
        {
            return View();
        }

        public ActionResult VerifyAndSign(int jaid)
        {
            return View(repo.GetJobAppById(jaid));
        }

        public HttpStatusCodeResult SaveXChanges(int jaid, string type, dynamic data)
        //public ActionResult SaveXChanges(int jaid, Position position, string fName, string lName)
        {
            var jobApp = repo.GetJobAppById(jaid);

            switch (type)
            {
                case "position":
                    jobApp.Position = (Position)int.Parse(data[0]);
                    break;
                case "fname":
                    jobApp.FName = (string)data[0];
                    break;
                case "lname":
                    jobApp.LName = (string)data[0];
                    break;
                default:
                    break;
            }

            repo.UpdateJobApp(jobApp);

            return new HttpStatusCodeResult(200);
        }
        
        public ActionResult UploadResume()
        {
            return View();
        }

        #endregion

        public async Task<ActionResult> Upload(HttpPostedFileBase file)
        {
            var empVM = new EmploymentViewModel();
            if (Request.Files.Count > 0)
            {
                string ext = Path.GetExtension(file.FileName);

                string filename = file.FileName.TrimEnd(ext.ToCharArray());

                //Calling the Dropbox API and the auth token.
                DropboxClient dpc = new DropboxClient(token);

                //Will Upload the Resume file to the folder on dropbox & overwrite any file that may have already been submitted with the same name.
                await dpc.Files.UploadAsync("/New Resumes/" + file.FileName, WriteMode.Overwrite.Instance, false, DateTime.Now, false, null, file.InputStream);
                
                //waiting for the Parsed resume to be returned to the new folder in JSON format.
                var m = await dpc.Files.DownloadAsync("/Parsed Resumes/" + filename + ".txt").Result.GetContentAsStringAsync();
                
                var emp = new Employment();
                var jobApp = new JobApp();

                jobApp.Resume = filename.Replace(' ', '+')+ext;

                //Checks if the user is logged in and sets the Date and Time for DateAvailable & LastEdit. //This was implemented to allow the form to populate.
                jobApp.Applicant = repo.GetCurrentAppUser(User.Identity.GetUserId());

                JsonConvert.PopulateObject(m, jobApp);
                //repo.CreateJobApp(jobApp);
                //repo.UpdateJobApp(jobApp);

               // emp.Id = Convert.ToInt32(Session["jaid"].ToString());
                JsonConvert.PopulateObject(m, emp);
                //repo.UpdateEmployment(emp);
                repo.CreateEmployment(emp);


                return View("Create", jobApp);
            }
            return View();
        }
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
