using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabsProject.BackEnd.Domain.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        void Add(T item);
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
     }
}
