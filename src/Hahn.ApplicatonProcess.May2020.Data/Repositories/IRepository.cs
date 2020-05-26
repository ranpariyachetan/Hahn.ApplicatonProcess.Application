using System;
using System.Collections.Generic;
using System.Text;

namespace Hahn.ApplicatonProcess.May2020.Data.Repositories
{
    public interface IRepository<T> where T:class
    {
        T Add(T entity);

        T Update(T entity);

        void Delete(int entityId);

        void Delete(T entity);

        T GetById(int entityId);

        IList<T> GetAll();
    }
}
