using LabsProject.BackEnd.Domain.ValueObjects;
using System;

namespace LabsProject.BackEnd.Domain.Entities
{
    public class Laboratories: Entity
    {
        public Laboratories(Guid id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
            StateId = State.Active.Id;
        }
        protected Laboratories() { }

        public string Name { get; private set; }
        public string Address { get; private set; }
        public int StateId { get; private set; }        

        public void RemoveLogicLaboratories()
        {
            if (StateId == State.Active.Id)
            {
                StateId = State.Inactive.Id;
            }
        }
    }
}
