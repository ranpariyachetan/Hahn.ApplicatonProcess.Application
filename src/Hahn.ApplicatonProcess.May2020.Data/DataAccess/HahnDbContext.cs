using Hahn.ApplicatonProcess.May2020.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Hahn.ApplicatonProcess.May2020.Data.DataAccess
{
    public class HahnDbContext : DbContext
    {
        public HahnDbContext(DbContextOptions<HahnDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //
            //modelBuilder.Entity<Applicant>().HasData(
            //    new Applicant { 
            //        ID = 1, 
            //        Name = "Johnny", 
            //        FamilyName = "Walker", 
            //        Address = "5th Ave, Las Vegas", 
            //        Age = 45, 
            //        CountryOfOrigin = "United States of America", 
            //        EmailAddress = "j.walker@jwalker.com", 
            //        Hired = false
            //    });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Applicant> Applicants { get; set; }

    }
}
