using System;
using System.Net;
using Hahn.ApplicatonProcess.May2020.Data.Repositories;
using Hahn.ApplicatonProcess.May2020.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hahn.ApplicatonProcess.May2020.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantRepository applicantRepository;
        private readonly ILogger<ApplicantController> logger;
        public ApplicantController(IApplicantRepository applicantRepository, ILogger<ApplicantController> logger)
        {
            this.applicantRepository = applicantRepository;
            this.logger = logger;
        }

        // GET: api/<ApplicantController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return new JsonResult(this.applicantRepository.GetAll());
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "Error while getting all applicants.");
                return new JsonResult(new { Error = new { Message = "An unhandled error occured during request processing." } });
            }
        }

        // GET api/<ApplicantController>/5
        //[HttpGet()]
        [HttpGet("{id}", Name =nameof(GetById))]
        public ActionResult GetById(int id)
        {
            try
            {
                var applicant = this.applicantRepository.GetById(id);

                if (applicant != null)
                    return new JsonResult(applicant);
                else
                {
                    this.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    return new JsonResult(new { Error = new { Message = $"Applicant with ID - {id} does not exist." } });
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error while getting applicant with ID - {id}.");
                return new JsonResult(new { Error = new { Message = "An unhandled error occured during request processing." } });
            }
        }

        // POST api/<ApplicantController>
        [HttpPost]
        public ActionResult Post([FromBody] Applicant value)
        {
            try
            {
                var savedEntity = this.applicantRepository.Add(value);

                var link = this.Url.ActionLink("GetById", "Applicant", savedEntity.ID);

                return CreatedAtAction("GetById", new { id = savedEntity.ID.ToString() }, savedEntity);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error while creating new applicant.");
                return new JsonResult(new { Error = new { Message = "An unhandled error occured during request processing." } });
            }
        }

        // PUT api/<ApplicantController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Applicant value)
        {
            try
            {
                if(id != value.ID)
                {
                    this.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new JsonResult(new { Error = new { Message = $"ApplicantID - {id} is not valid." } });
                }
                var applicant = this.applicantRepository.GetById(id);

                if(applicant == null)
                {
                    this.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new JsonResult(new { Error = new { Message = $"ApplicantID - {id} is not valid." } });
                }

                applicant.Name = value.Name;
                applicant.FamilyName = value.FamilyName;
                applicant.Address = value.Address;
                applicant.EmailAddress = value.EmailAddress;
                applicant.CountryOfOrigin = value.CountryOfOrigin;
                applicant.Age = value.Age;
                applicant.Hired = value.Hired;

                var savedEntity = this.applicantRepository.Update(applicant);

                return AcceptedAtAction("GetById", new { id = savedEntity.ID.ToString() }, savedEntity);
            }
            catch(Exception ex)
            {
                logger.LogError(ex, $"Error while updating applicant with ID - {id}.");
                return new JsonResult(new { Error = new { Message = "An unhandled error occured during request processing." } });
            }
        }

        // DELETE api/<ApplicantController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var applicant = this.applicantRepository.GetById(id);

                if (applicant == null)
                {
                    this.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return new JsonResult(new { Error = new { Message = $"ApplicantID - {id} is not valid." } });
                }

                this.applicantRepository.Delete(applicant);

                return new EmptyResult();
            }
            catch(Exception ex)
            {
                logger.LogError(ex, $"Error while deleting applicant with ID - {id}.");
                return new JsonResult(new { Error = new { Message = "An unhandled error occured during request processing." } });
            }
        }
    }
}
