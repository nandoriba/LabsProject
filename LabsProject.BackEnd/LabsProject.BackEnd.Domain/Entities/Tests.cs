using LabsProject.BackEnd.Domain.ValueObjects;

namespace LabsProject.BackEnd.Domain.Entities
{
    public class Tests : Entity 
    {
        public Tests(string name, string type)
        {
            Name = name;
            Type = type;
            StateId = State.Active.Id;
        }
        protected Tests() { }

        public string Name { get; private set; }
        public string Type { get; private set; }
        public int StateId { get; private set; }
        public void RemoveLogicTests()
        {
            if (StateId == State.Active.Id)
            {
                StateId = State.Inactive.Id;
            }
        }
    }
}
