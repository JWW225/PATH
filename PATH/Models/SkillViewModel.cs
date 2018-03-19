using ProvalusApplicantTrackingHub.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProvalusApplicantTrackingHub.Models
{
    public class SkillViewModel
    {
        public int JAID { get; set; }

        public int SelectedTech { get; set; }

        public Position Position { get; set; }

        public List<Skill> Skills { get; set; }

        public Skill NewSkill { get; set; }

        public List<Technology> TechDropList {
            get { return PathRepository.Repo.GetTechnologiesByPosition(Position); }
        }
    }
}