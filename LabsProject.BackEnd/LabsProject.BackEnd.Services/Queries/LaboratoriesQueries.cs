using System;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using LabsProject.BackEnd.Domain.Entities;
using LabsProject.BackEnd.Domain.Queries;
using LabsProject.BackEnd.Domain.ValueObjects;

namespace LabsProject.BackEnd.Services.Queries
{
    public class LaboratoriesQueries: ILaboratoriesQueries
    {
        private string _connectionString = string.Empty;        

        public LaboratoriesQueries(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr) ? constr : throw new ArgumentNullException(nameof(constr));
        }
        public async Task<Laboratories> GetById(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryFirstAsync<Laboratories>(
                      String.Format("Select * From Laboratorie Where StateId = {0} And Id = {1}",
                                  State.Active.Id, id));
            }
        }
        public async Task<IEnumerable<Laboratories>> GetAllActive()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<Laboratories>(
                    String.Format("Select * From Laboratorie Where StateId = {0}", 
                                  State.Active.Id));
            }
        } 
        public async Task<IEnumerable<Laboratories>> GetLabsActiveByNameTest()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                return await connection.QueryAsync<Laboratories>(
                    String.Format(@"Select * From Laboratorie Where StateId = {0}",
                                  State.Active.Id));
            }
        }
        
    }
}
