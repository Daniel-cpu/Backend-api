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
    public class CandidateController : ApiController //GENERAMOS NUESTAR CALSE QUE HEREDÁ SU PROPIEDADES DEL ApiContoller
    {
        // GET api/<controller>
        [HttpGet]//CONFIGURACION EXPLCITA DEL TIPO DE METODO HTTP EN ESTE CASO GET
        [Route("api/Candidate")]// CONFIGURACIÓN EXPLICITA DE LA RUTA (URL DE LA PETICIÓN) DE ACCESO AL METODO GET
        public List<candidates> Get()//SE CREA UNA LISTA DE TIPO DE ACCESO PUBLICA, ACCESIBLE A TRAVÉS DEL METODO GET 
        {
            return CandidateData.Leer();// RETORNA LA LISTA CON LOS DATOS OBTENIDOS POR EL MODELO
        }


        // GET api/<controller>/5

        [HttpGet]
        [Route("api/Candidate/{id_Candidate}")]
        public candidates Get(int id_Candidate)
        {
            return CandidateData.Obtener(id_Candidate);
        }

        // POST api/<controller>
        [HttpPost]
        [Route("api/Candidate/Post")]
        public bool Post([FromBody] candidates oCandidate)
        {
            return CandidateData.Insertar(oCandidate);
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("api/Candidate/Put")]
        public bool Put([FromBody] candidates oCandidate)
        {
            return CandidateData.Modificar(oCandidate);
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("api/Candidate/delete/{id_Candidate}")]
        public bool Delete(int id_Candidate)
        {
            return CandidateData.Eliminar(id_Candidate);
        }
    }
}