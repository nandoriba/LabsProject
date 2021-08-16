using System;
using System.Collections.Generic;

namespace LabsProject.BackEnd.Domain.EntitesDTO
{
    public class TestWithActiveLabsDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set ; }
        public string Type { get; set; }
        public int StateId { get; set; }
        public List<LaboratoriesDTO> Laboratories { get; set; }
    }
    public class LaboratoriesDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int StateId { get; set; }
    }

}
