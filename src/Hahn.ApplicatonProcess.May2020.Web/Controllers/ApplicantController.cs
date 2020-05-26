using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.May2020.Data.DataAccess;
using Hahn.ApplicatonProcess.May2020.Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hahn.ApplicatonProcess.May2020.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly HahnDbContext dbContext;
        public ApplicantController(HahnDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<ApplicantController>
        [HttpGet]
        public IEnumerable<Applicant> Get()
        {
            return new List<Applicant>();
        }

        // GET api/<ApplicantController>/5
        [HttpGet("{id}")]
        public Applicant Get(int id)
        {
            return new Applicant();
        }

        // POST api/<ApplicantController>
        [HttpPost]
        public void Post([FromBody] Applicant value)
        {
        }

        // PUT api/<ApplicantController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Applicant value)
        {
        }

        // DELETE api/<ApplicantController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
