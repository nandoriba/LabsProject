using LabsProject.BackEnd.Domain.Commands;
using LabsProject.BackEnd.Domain.Commands.Laboratories;
using LabsProject.BackEnd.Domain.Handlers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LabsProject.BackEnd.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LaboratoriesCollectionController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public IEnumerable<GenericCommandsResult> CreateCollection(
          [FromBody] IEnumerable<CreateLaboratoriesCommand> command,
          [FromServices] LaboratoriesHandler handler)
        {
            return (IEnumerable<GenericCommandsResult>)handler.Handler(command);
        }
        [Route("")]
        [HttpDelete]
        public IEnumerable<GenericCommandsResult> DeleteCollection(
           [FromBody] IEnumerable<RemoveLaboratoriesCommand> command,
           [FromServices] LaboratoriesHandler handler)
        {
            return (IEnumerable<GenericCommandsResult>)handler.Handler(command);
        }
        [Route("")]
        [HttpPut]
        public IEnumerable<GenericCommandsResult> UpdateCollection(
            [FromBody] IEnumerable<UpdateLaboratoriesCommand> command,
            [FromServices] LaboratoriesHandler handler)
        {
            return (IEnumerable<GenericCommandsResult>)handler.Handler(command);
        }
    }
}
