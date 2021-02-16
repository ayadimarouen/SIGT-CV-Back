using SIGT.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGT.DTO
{
    public class ExperienceDTO
    {
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Title { get; set; }
        public string Company { get; set; }
        public List<string> Skills { get; set; }
        public List<TasksDTO> Tasks { get; set; }
    }
}
