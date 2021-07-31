using Dapper;
using LabsProject.BackEnd.Domain.Entities;
using LabsProject.BackEnd.Domain.Queries;
using LabsProject.BackEnd.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace LabsProject.BackEnd.Services.Queries
{
    public class AssociateLabsWithTestsQueries: IAssociateLabsWithTestsQueries
    {        
        private string _connectionString;

        public AssociateLabsWithTestsQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }

        public Task<IEnumerable<AssociateLabsWithTests>> GetLaboratoriesIdByLabId(Guid testId)
        {
            throw new NotImplementedException();
        }
    }
}
