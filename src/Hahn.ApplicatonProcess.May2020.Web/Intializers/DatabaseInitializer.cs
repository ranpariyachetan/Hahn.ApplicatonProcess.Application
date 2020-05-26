using System.Collections.Generic;
using Hahn.ApplicatonProcess.May2020.Data.DataAccess;
using Hahn.ApplicatonProcess.May2020.Domain.Models;

namespace Hahn.ApplicatonProcess.May2020.Web.Intializers
{
    public class DatabaseInitializer
    {
        private readonly HahnDbContext dbContext;
        public DatabaseInitializer(HahnDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void PopulateInitialData()
        {
            var applicants = new List<Applicant> {
                new Applicant
                {
                    ID = 1,
                    Name = "Arvind",
                    FamilyName = "Kumar",
                    Address = "M G Road, Bangalore",
                    Age = 35,
                    CountryOfOrigin = "India",
                    EmailAddress = "akumar@gmail.com",
                    Hired = false
                },
                new Applicant
                {
                    ID = 2,
                    Name = "Steve",
                    FamilyName = "Martin",
                    Address = "5th Ave, Las Vegas",
                    Age = 32,
                    CountryOfOrigin = "United States of America",
                    EmailAddress = "steve.martin@hotmail.com",
                    Hired = false
                },
                new Applicant
                {
                    ID = 3,
                    Name = "Bjorn",
                    FamilyName = "Hough",
                    Address = "Kuholmsveien Kristiansand",
                    Age = 40,
                    CountryOfOrigin = "Lund",
                    EmailAddress = "b.hough@gmail.com",
                    Hired = false
                }
            };

            dbContext.Applicants.AddRange(applicants);

            dbContext.SaveChanges();
        }
    }
}
