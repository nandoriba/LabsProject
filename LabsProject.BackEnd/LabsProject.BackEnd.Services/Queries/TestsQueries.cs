using Dapper;
using LabsProject.BackEnd.Domain.EntitesDTO;
using LabsProject.BackEnd.Domain.Entities;
using LabsProject.BackEnd.Domain.Queries;
using LabsProject.BackEnd.Domain.ValueObjects;
using Newtonsoft.Json;
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
        public async Task<TestWithActiveLabsDTO> GetTestWithActiveLabs(Guid idTest)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();              

                var result = await connection.QueryAsync<dynamic>(
                      String.Format("SELECT Test.Id, Test.Name, Test.Type, Test.StateId, Laboratorie.Id AS LabId, " +
                                    "Laboratorie.Name AS LabName, Laboratorie.Address AS LabAddress, Laboratorie.StateId AS LabStateId " +
                                     "FROM AssociateLabsWithTests INNER JOIN " +
                                     "Test ON AssociateLabsWithTests.TestsId = Test.Id INNER JOIN " +
                                     "Laboratorie ON AssociateLabsWithTests.LaboratoriesId = Laboratorie.Id " +
                                     "WHERE(Laboratorie.StateId = {0}) AND(Test.StateId = {0}) AND(Test.Id = '{1}')" +
                                     "ORDER BY Test.Name, LabName",
                                  State.Active.Id, idTest));

                if (result.AsList().Count == 0)
                    throw new KeyNotFoundException();

                return MapTestWithActiveLabs(result);
            }
        }
        private TestWithActiveLabsDTO MapTestWithActiveLabs(dynamic result)
        {
            var testWithActiveLabsDTO = new TestWithActiveLabsDTO()
            {
                Id = result[0].Id,
                Name = result[0].Name,
                Type = result[0].Type,
                StateId = result[0].StateId,
                Laboratories = new List<LaboratoriesDTO>()
            };

            foreach (dynamic item in result)
            {
                var laboratoriesDTO = new LaboratoriesDTO()
                {
                    Id = item.LabId,
                    Name = item.LabName,
                    Address = item.LabAddress,
                    StateId = item.LabStateId
                };
                testWithActiveLabsDTO.Laboratories.Add(laboratoriesDTO);
            }
            return testWithActiveLabsDTO;
        }
    }
}
