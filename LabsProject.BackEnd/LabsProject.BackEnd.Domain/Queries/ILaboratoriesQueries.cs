using LabsProject.BackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabsProject.BackEnd.Domain.Queries
{
    public interface ILaboratoriesQueries
    {
        Task<Laboratories> GetById(Guid id);
        Task<IEnumerable<Laboratories>> GetAllActive();
        Task<IEnumerable<Laboratories>> GetLabsActiveByNameTest();
    }
}
