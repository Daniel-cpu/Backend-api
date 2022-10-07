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
    public class CityController : ApiController
    {
        // GET api/<controller>

        [Route("api/City")]
        public List<City> Get()
        {
            return CityData.Leer();
        }


        // GET api/<controller>/5

        [HttpGet]
        [Route("api/City/{Code}")]
        public City Get(int Code)
        {
            return CityData.Obtener(Code);
        }

        // POST api/<controller>
        [Route("api/City/Post")]
        public bool Post([FromBody] City oCity)
        {
            return CityData.Insertar(oCity);
        }

        // PUT api/<controller>/5
        [Route("api/City/Put")]
        public bool Put([FromBody] City oCity)
        {
            return CityData.Modificar(oCity);
        }

        // DELETE api/<controller>/5
        [Route("api/City/delete/{Code}")]
        public bool Delete(int code)
        {
            return CityData.Eliminar(code);
        }
    }
}