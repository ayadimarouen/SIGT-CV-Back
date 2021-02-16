using SIGT.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGT.DTO
{
    public class EducationDTO
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Label { get; set; }
        public string Institute { get; set; }
    }
}
