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
    public class TestsQueries: ITestsQueries
    {
        private string _connectionString = string.Empty;

        public TestsQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }
        public async Task<Tests> GetById(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryFirstAsync<Tests>(
                      String.Format("Select * From Test Where StateId = {0} And Id = {1}",
                                  State.Active.Id, id));
            }
        }
        public async Task<IEnumerable<Tests>> GetAllActive()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<Tests>(
                    String.Format("Select * From Test Where StateId = {0}",
                                  State.Active.Id));
            }
        }
        public async Task<Tests> GetByName(string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryFirstAsync<Tests>(
                      String.Format("Select * From Test Where StateId = {0} And Name like '{1}'",
                                  State.Active.Id, name));
            }
        }
    }
}
