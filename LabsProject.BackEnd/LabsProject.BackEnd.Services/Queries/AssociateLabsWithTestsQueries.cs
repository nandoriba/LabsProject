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
    
        public async Task<IEnumerable<AssociateLabsWithTests>> GetLaboratoriesIdByLabId(Guid testId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<AssociateLabsWithTests>(
                    String.Format("Select * From AssociateLabsWithTests Where StateId = {0} And TestsId = {1}",
                                  State.Active.Id, testId));
            }
        }
    }
}
