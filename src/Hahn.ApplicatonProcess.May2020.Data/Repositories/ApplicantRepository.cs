using System;
using System.Collections.Generic;
using System.Linq;
using Hahn.ApplicatonProcess.May2020.Data.DataAccess;
using Hahn.ApplicatonProcess.May2020.Domain.Models;

namespace Hahn.ApplicatonProcess.May2020.Data.Repositories
{
    public class ApplicantRepository : BaseRepository, IApplicantRepository
    {
        public ApplicantRepository(HahnDbContext dbContext) : base(dbContext)
        {

        }

        public Applicant Add(Applicant entity)
        {
            var maxId = this.dbContext.Applicants.Max(a => a.ID);
            entity.ID = maxId + 1;
            dbContext.Applicants.Add(entity);

            dbContext.SaveChanges();
            return entity;
        }

        public void Delete(int entityId)
        {
            var entity = GetById(entityId);

            if (entity != null)
            {
                this.dbContext.Applicants.Remove(entity);
                this.dbContext.SaveChanges();
            }
        }       

        public Applicant GetById(int entityId)
        {
            return this.dbContext.Applicants.FirstOrDefault(a => a.ID == entityId);
        }

        public Applicant Update(Applicant entity)
        {
            throw new NotImplementedException();
        }

        public IList<Applicant> GetAll()
        {
            return dbContext.Applicants.ToList();
        }
    }
}
