using System;
using System.Net;
using Hahn.ApplicatonProcess.May2020.Data.Repositories;
using Hahn.ApplicatonProcess.May2020.Domain.Models;
using Hahn.ApplicatonProcess.May2020.Web.Swagger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Filters;

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

        /// <summary>
        /// Gets list of all applicants.
        /// </summary>
        /// <returns>The collection of all applicants.</returns>
        // GET: api/<ApplicantController>
        [Produces("application/json")]
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

        /// <summary>
        /// Gets details of an applicant with specified id.
        /// </summary>
        /// <param name="id">Id of applicant.</param>
        /// <returns>Details of applicant.</returns>
        // GET api/<ApplicantController>/5
        [Produces("application/json")]
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

        /// <summary>
        /// Saves details of new applicant.
        /// </summary>
        /// <param name="value">Applicant object.</param>
        /// <returns>Saved details of applicant.</returns>
        // POST api/<ApplicantController>
        [SwaggerRequestExample(typeof(Applicant), typeof(ApplicantModelPostExample))]
        [ProducesResponseType(typeof(Applicant), (int)HttpStatusCode.Created)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json")]
        [Consumes("application/json")]
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

        /// <summary>
        /// Updates details of applicant with specified id.
        /// </summary>
        /// <param name="id">Id of applicant.</param>
        /// <param name="value">Applicant object.</param>
        /// <returns>Details of updated applicant.</returns>
        // PUT api/<ApplicantController>/5
        [SwaggerRequestExample(typeof(Applicant), typeof(ApplicantModelPutExample))]
        [ProducesResponseType(typeof(Applicant), (int)HttpStatusCode.Accepted)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json")]
        [Consumes("application/json")]
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

        /// <summary>
        /// Deletes applicant with specified if.
        /// </summary>
        /// <param name="id">Id of applicant.</param>
        /// <returns>Empty response.</returns>
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
