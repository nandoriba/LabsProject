using System;

namespace LabsProject.BackEnd.Domain.Entities
{
    public abstract class Entity : IEquatable<Entity>
    {      
        public Guid Id { get; set; }

        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }     
    }
}
