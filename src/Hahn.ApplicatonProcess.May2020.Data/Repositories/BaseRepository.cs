using System;
using System.Collections.Generic;
using System.Text;
using Hahn.ApplicatonProcess.May2020.Data.DataAccess;

namespace Hahn.ApplicatonProcess.May2020.Data.Repositories
{
    public class BaseRepository
    {
        protected readonly HahnDbContext dbContext;
        public BaseRepository(HahnDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
