using LabsProject.BackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabsProject.BackEnd.Domain.Queries
{
    public interface IAssociateLabsWithTestsQueries
    {
        Task<IEnumerable<AssociateLabsWithTests>> GetLaboratoriesIdByLabId(Guid testId);
    }
}
