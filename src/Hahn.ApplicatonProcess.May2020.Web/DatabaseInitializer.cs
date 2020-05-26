using Hahn.ApplicatonProcess.May2020.Data.DataAccess;
using Hahn.ApplicatonProcess.May2020.Domain.Models;

namespace Hahn.ApplicatonProcess.May2020.Web
{
    public static class DatabaseInitializer
    {
        public static void PopulateInitialData(HahnDbContext dbContext)
        {
            var applicant = new Applicant();

            dbContext.Applicants.Add(applicant);

            dbContext.SaveChanges();

            
        }
    }
}
