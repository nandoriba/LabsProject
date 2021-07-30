using LabsProject.BackEnd.Domain.Entities;
using System.Collections.Generic;

namespace LabsProject.BackEnd.Domain.Repositories
{
    public interface ITestsRepository: IRepositoryBase<Tests>
    {
        void Update(Tests item);
    }
}
