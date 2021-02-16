using SIGT.Entities;
using System.Collections.Generic;

namespace SIGT.DTO
{
    public class CvDTO
    {
        public string Title { get; set; }
        public string FullName { get; set; }
        public int? Age { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Linkedin { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public List<ExperienceDTO> Experiences { get; set; }
        public List<EducationDTO> Educations{ get; set; }
        public List<InterestDTO> Interests { get; set; }
        public List<SkillsDTO> Skills { get; set; }
        public List<LanguageDTO> Languages { get; set; }
    }

}
