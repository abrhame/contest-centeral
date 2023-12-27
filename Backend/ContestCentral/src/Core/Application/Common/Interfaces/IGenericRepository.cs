using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContestCentral.Application.Persistence.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task<List<T>> GetAll();
        Guid Add(T entity);
        Task Update(T entity);
        void Delete(T entity);
       
    }
}