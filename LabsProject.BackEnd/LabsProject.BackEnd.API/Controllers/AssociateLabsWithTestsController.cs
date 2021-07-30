using LabsProject.BackEnd.Domain.Commands;
using LabsProject.BackEnd.Domain.Commands.AssociateLabsWithTests;
using LabsProject.BackEnd.Domain.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabsProject.BackEnd.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AssociateController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericCommandsResult Create(
            [FromBody] CreateAssociateCommand command,
            [FromServices] AssociateLabsWithTestsHandler handler)
        {
            return (GenericCommandsResult)handler.Handler(command);
        }
        [Route("")]
        [HttpDelete]
        public GenericCommandsResult Delete(
            [FromBody] RemoveAssociateCommand command,
            [FromServices] AssociateLabsWithTestsHandler handler)
        {
            return (GenericCommandsResult)handler.Handler(command);
        }
    }
}
