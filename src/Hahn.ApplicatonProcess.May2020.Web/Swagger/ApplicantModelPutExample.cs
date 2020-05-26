using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hahn.ApplicatonProcess.May2020.Domain.Models;
using Swashbuckle.AspNetCore.Filters;

namespace Hahn.ApplicatonProcess.May2020.Web.Swagger
{
    public class ApplicantModelPutExample : IExamplesProvider<Applicant>
    {
        public Applicant GetExamples()
        {
            return new Applicant
            {
                ID = 4,
                Name = "Ethan",
                FamilyName = "Tresse",
                Address = "Concord Street, Orlando, FL 32801",
                CountryOfOrigin = "United States Of America",
                Age = 29,
                EmailAddress = "ethan.tresse@aol.com",
                Hired = true
            };
        }
    }
}
