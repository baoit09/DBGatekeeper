using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBGatekeeper.Models
{
    public class StudyViewModel
    {
        public int DiseaseID { get; set; }
        public int PatientID { get; set; }
        public string DiseaseName { get; set; }
        public string Description { get; set; }
        public DateTime? DiseaseDate { get; set; }
    }
}