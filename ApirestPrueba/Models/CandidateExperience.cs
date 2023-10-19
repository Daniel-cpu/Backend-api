using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApirestPrueba.Models
{
    public class CandidateExperience
    {
        public int IDCANDIDATEEXPERIENCE { get; set; }
        public int IDCANDIDATE { get; set; }
        public string COMPANY { get; set; }
        public string JOB { get; set; }
        public string DESCRIPTION { get; set; }
        public Int32 SALARY { get; set; }
        public DateTime BEGINDATE { get; set; }
        public DateTime ENDDATE { get; set; }
        public DateTime? INSERTDATE { get; set; }
        public DateTime? MODIFYDATE { get; set; }

    }
   

}