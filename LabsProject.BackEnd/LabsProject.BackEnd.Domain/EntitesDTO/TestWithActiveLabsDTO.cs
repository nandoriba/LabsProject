using System;
using System.Collections.Generic;

namespace LabsProject.BackEnd.Domain.EntitesDTO
{
    public record TestWithActiveLabsDTO
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Type { get; init; }
        public int StateId { get; init; }
        public List<LaboratoriesDTO> Laboratories { get; set; }
    }
    public record LaboratoriesDTO
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Address { get; init; }
        public int StateId { get; init; }
    }

}
