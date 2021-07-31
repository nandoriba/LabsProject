using LabsProject.BackEnd.Domain.Commands;
using LabsProject.BackEnd.Domain.Commands.Tests;
using LabsProject.BackEnd.Domain.Entities;
using LabsProject.BackEnd.Domain.Handlers;
using LabsProject.BackEnd.Domain.Queries;
using LabsProject.BackEnd.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabsProject.BackEnd.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly ITestsQueries _testsQueries;

        public TestsController(ITestsQueries testsQueries)
        {
            _testsQueries = testsQueries;
        }

        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<Tests>> GetAll(
           [FromServices] ITestsRepository repository)
        {
            return await repository.GetAll();
        }
        [Route("activelabs")]
        [HttpGet]
        public async Task<JsonResult> GetAssociationActiveLabs(Guid idTest)
        {
            var result = await _testsQueries.GetTestWithActiveLabs(idTest);
            return new JsonResult(result);
        }

        [Route("test")]
        [HttpGet()]
        public async Task<Tests> GetLab(
            [FromServices] ITestsRepository repository, Guid id)
        {
            return await repository.GetById(id);
        }

        [Route("")]
        [HttpPost]
        public GenericCommandsResult Create(
            [FromBody] CreateTestsCommand command,
            [FromServices] TestsHandler handler)
        {
            return (GenericCommandsResult)handler.Handler(command);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandsResult Update(
            [FromBody] UpdateTestsCommand command,
            [FromServices] TestsHandler handler)
        {
            return (GenericCommandsResult)handler.Handler(command);
        }

        [Route("")]
        [HttpDelete]
        public GenericCommandsResult Delete(
            [FromBody] RemoveTestsCommand command,
            [FromServices] TestsHandler handler)
        {
            return (GenericCommandsResult)handler.Handler(command);
        }
    }
}
