using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApirestPrueba.Models
{
    public class candidates
    {
        public int ID_CANDIDATE { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public DateTime BIRTHDATE { get; set; }
        public string EMAIL { get; set; }
        public DateTime? INSERTDATE { get; set; }
        public DateTime? MODIFYDATE { get; set; }

    }
}