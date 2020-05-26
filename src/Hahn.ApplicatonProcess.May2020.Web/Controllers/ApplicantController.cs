using System.Collections.Generic;
using System.Net;
using Hahn.ApplicatonProcess.May2020.Data.DataAccess;
using Hahn.ApplicatonProcess.May2020.Data.Repositories;
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
        private readonly IApplicantRepository applicantRepository;
        public ApplicantController(HahnDbContext dbContext, IApplicantRepository applicantRepository)
        {
            this.dbContext = dbContext;
            this.applicantRepository = applicantRepository;
        }

        // GET: api/<ApplicantController>
        [HttpGet]
        public IEnumerable<Applicant> Get()
        {
            return this.dbContext.Applicants;
        }

        // GET api/<ApplicantController>/5
        //[HttpGet()]
        [HttpGet("{id}", Name =nameof(GetById))]
        public Applicant GetById(int id)
        {
            var applicant = this.applicantRepository.GetById(id);

            if(applicant != null)
                return applicant;
            else
            {
                this.Response.StatusCode = (int)HttpStatusCode.NotFound;
                return null;
            }
        }

        // POST api/<ApplicantController>
        [HttpPost]
        public ActionResult Post([FromBody] Applicant value)
        {
            var savedEntity = this.applicantRepository.Add(value);

            var link = this.Url.ActionLink("GetById", "Applicant", savedEntity.ID);

            return CreatedAtAction("GetById", new { id = savedEntity.ID.ToString() }, savedEntity);
            //return new CreatedAtRouteResult("GetById", savedEntity.ID, savedEntity);
            
            //return Created(new Uri(this.Url.Action("GetById", "Applicant", savedEntity.ID), UriKind.Relative), savedEntity);

            //this.Url.Action("GetById", "Applicant", savedEntity.ID)
            //return Created( CreatedAtAction(nameof(Get), savedEntity.ID);
            //return new JsonResult(savedEntity);
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
