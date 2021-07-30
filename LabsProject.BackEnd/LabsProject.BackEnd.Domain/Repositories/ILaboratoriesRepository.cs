using LabsProject.BackEnd.Domain.Entities;
using System.Collections.Generic;

namespace LabsProject.BackEnd.Domain.Repositories
{
    public interface ILaboratoriesRepository: IRepositoryBase<Laboratories>
    {
        void Update(Laboratories item); 
    }
}
