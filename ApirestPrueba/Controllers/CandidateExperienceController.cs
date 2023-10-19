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
    public class CandidateExperienceController : ApiController
    {
        // GET api/<controller>
        [HttpGet]
        [Route("api/candidateexperience")]
        public List<CandidateExperience> Get()
        {
            return CandidateExperienceData.ReadCandidateExperience();
        }

        // GET api/<controller>/5

        [HttpGet]
        [Route("api/candidateexperience/{id_CandidateExperience}")]
        public CandidateExperience Get(int id_CandidateExperience)
        {
            return CandidateExperienceData.ObtenerCandidateExperience(id_CandidateExperience);
        }

        // POST api/<controller>
        [HttpPost]
        [Route("api/candidateexperience/Post")]
        public bool Post([FromBody] CandidateExperience oCandidateExperience)
        {
            return CandidateExperienceData.InsertarCandidateExperience(oCandidateExperience);
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("api/candidateexperience/Put")]
        public bool Put([FromBody] CandidateExperience oCandidateExperience)
        {
            return CandidateExperienceData.ModificarCandidateExperience(oCandidateExperience);
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("api/candidateexperience/delete/{id_CandidateExperience}")]
        public bool Delete(int id_CandidateExperience)
        {
            return CandidateExperienceData.EliminarCandidateExperience(id_CandidateExperience);
        }
    }
}