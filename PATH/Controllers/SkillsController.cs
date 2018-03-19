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
    public class SkillsController : Controller
    {
        private IPathRepository repo = new PathRepository();

        // GET: Skills
        public ActionResult Index(int jaid)
        {

            TempData["jaid"] = jaid;
            var jobapp = repo.GetJobAppById(jaid);


            var skills = repo.GetSkillsByJobAppId(jaid).Count > 0 ? repo.GetSkillsByJobAppId(jaid) : new List<Skill>() { new Skill() { } };


            var skillVM = new SkillViewModel
            {
                JAID = jaid,
                Position = jobapp.Position,
                Skills = skills,
                NewSkill = new Skill()
            };

            return View(skillVM);
        }

        // GET: Skills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill skill = repo.GetSkillById(id ?? 0);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        // GET: Skills/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Skills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "Skills,Position" , Include = "SelectedTech,JAID,NewSkill")] SkillViewModel skillVM)
        {
            if (true)
            {
                skillVM.NewSkill.JobApp = repo.GetJobAppById(skillVM.JAID);
                skillVM.NewSkill.Technology = repo.GetTechnologyById(skillVM.SelectedTech);
                repo.CreateSkill(skillVM.NewSkill);
                return RedirectToAction("Index", new { jaid = skillVM.JAID });
            }

            return View(skillVM);
        }

        // GET: Skills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill skill = repo.GetSkillById(id ?? 0);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        // POST: Skills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Explanation,Proficiency")] Skill skill)
        {
            if (ModelState.IsValid)
            {
                repo.UpdateSkill(skill);
                return RedirectToAction("Index", skill.JobApp.Id);
            }
            return View(skill);
        }

        // GET: Skills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skill skill = repo.GetSkillById(id ?? 0);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        // POST: Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Skill skill = repo.GetSkillById(id);
            repo.DeleteSkill(id);

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
