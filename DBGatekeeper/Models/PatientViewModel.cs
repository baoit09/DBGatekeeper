using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBGatekeeper.Models
{
    public class PatientViewModel
    {
        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public DateTime? DOB { get; set; }
        public int Gender { get; set; }
    }
}