using LabsProject.BackEnd.Domain.Commands;
using LabsProject.BackEnd.Domain.Commands.Tests;
using LabsProject.BackEnd.Domain.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LabsProject.BackEnd.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TestsCollectionController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public IEnumerable<GenericCommandsResult> CreateCollection(
          [FromBody] IEnumerable<CreateTestsCommand> command,
          [FromServices] TestsHandler handler)
        {
            return (IEnumerable<GenericCommandsResult>)handler.Handler(command);
        }
        [Route("")]
        [HttpDelete]
        public IEnumerable<GenericCommandsResult> DeleteCollection(
           [FromBody] IEnumerable<RemoveTestsCommand> command,
           [FromServices] TestsHandler handler)
        {
            return (IEnumerable<GenericCommandsResult>)handler.Handler(command);
        }
        [Route("")]
        [HttpPut]
        public IEnumerable<GenericCommandsResult> UpdateCollection(
            [FromBody] IEnumerable<UpdateTestsCommand> command,
            [FromServices] TestsHandler handler)
        {
            return (IEnumerable<GenericCommandsResult>)handler.Handler(command);
        }
    }
}
