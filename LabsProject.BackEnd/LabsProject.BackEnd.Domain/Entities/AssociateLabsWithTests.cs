using System;

namespace LabsProject.BackEnd.Domain.Entities
{
    public class AssociateLabsWithTests: Entity
    {
        public AssociateLabsWithTests(Guid laboratoriesId, Guid testsId)
        {
            LaboratoriesId = laboratoriesId;
            TestsId = testsId;
        }
        protected AssociateLabsWithTests() { }

        public Guid LaboratoriesId { get; private set; }
        public Guid TestsId { get; private set; }
        
    }
}
