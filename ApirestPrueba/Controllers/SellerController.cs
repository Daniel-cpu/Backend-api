using ApirestPrueba.Data;
using ApirestPrueba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApirestPrueba.Controllers
{
    public class SellerController : ApiController
    {
        // GET api/<controller>

        [Route("api/seller")]
        public List<Seller> Get()
        {
            return SellerData.LeerSeller();
        }

        // GET api/<controller>/5

        [HttpGet]
        [Route("api/seller/{Code}")]
        public Seller Get(int Code)
        {
            return SellerData.ObtenerSeller(Code);
        }

        // POST api/<controller>
        [Route("api/Seller/Post")]
        public bool Post([FromBody] Seller oSeller)
        {
            return SellerData.InsertarSeller(oSeller);
        }

        // PUT api/<controller>/5
        [Route("api/Seller/Put")]
        public bool Put([FromBody] Seller oSeller)
        {
            return SellerData.ModificarSeller(oSeller);
        }

        // DELETE api/<controller>/5
        [Route("api/Seller/delete/{Code}")]
        public bool Delete(int code)
        {
            return SellerData.EliminarSeller(code);
        }
    }
}