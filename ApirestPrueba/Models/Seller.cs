using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApirestPrueba.Models
{
    public class Seller
    {
        public int CODE { get; set; }
        public string NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string DOCUMENT { get; set; }
        public int CITY_ID { get; set; }
    }
}