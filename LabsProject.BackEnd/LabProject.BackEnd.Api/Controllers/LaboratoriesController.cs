using LabsProject.BackEnd.Domain.Commands;
using LabsProject.BackEnd.Domain.Commands.Laboratories;
using LabsProject.BackEnd.Domain.Entities;
using LabsProject.BackEnd.Domain.Handlers;
using LabsProject.BackEnd.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LabsProject.BackEnd.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LaboratoriesController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public async Task<IEnumerable<Laboratories>> GetAll(
            [FromServices] ILaboratoriesRepository repository)
        {
            return await repository.GetAll();
        }
        [Route("lab")] 
        [HttpGet()]
        public async Task<Laboratories> GetLab(
            [FromServices]ILaboratoriesRepository repository, Guid id)
        {
            return await repository.GetById(id);
        }   
        
        [Route("")]
        [HttpPost]
        public GenericCommandsResult Create(
            [FromBody]CreateLaboratoriesCommand command, 
            [FromServices]LaboratoriesHandler handler )
        {
            return (GenericCommandsResult)handler.Handler(command);
        }       

        [Route("addlabs")]
        [HttpPut]
        public GenericCommandsResult Update(
            [FromBody] UpdateLaboratoriesCommand command,
            [FromServices] LaboratoriesHandler handler)
        {
            return (GenericCommandsResult)handler.Handler(command);
        }

        [Route("")]
        [HttpDelete]
        public GenericCommandsResult Delete(
            [FromBody] RemoveLaboratoriesCommand command,
            [FromServices] LaboratoriesHandler handler)
        {
            return (GenericCommandsResult)handler.Handler(command);
        }
    }
}
