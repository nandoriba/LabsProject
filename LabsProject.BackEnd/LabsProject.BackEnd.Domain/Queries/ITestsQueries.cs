using LabsProject.BackEnd.Domain.EntitesDTO;
using LabsProject.BackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabsProject.BackEnd.Domain.Queries
{
    public interface ITestsQueries
    {
        Task<Tests> GetById(Guid id);
        Task<IEnumerable<Tests>> GetAllActive();
        Task<Tests> GetByName(string name);
        Task<TestWithActiveLabsDTO> GetTestWithActiveLabs(Guid idTest);
    }
}
