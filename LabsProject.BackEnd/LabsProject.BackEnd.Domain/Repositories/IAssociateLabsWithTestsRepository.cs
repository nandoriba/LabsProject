using LabsProject.BackEnd.Domain.Entities;
using System;

namespace LabsProject.BackEnd.Domain.Repositories
{
    public interface IAssociateLabsWithTestsRepository: IRepositoryBase<AssociateLabsWithTests>
    {
        void Remove(AssociateLabsWithTests item);
    }
}
