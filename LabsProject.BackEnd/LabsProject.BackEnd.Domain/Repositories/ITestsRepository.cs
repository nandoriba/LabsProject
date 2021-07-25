using LabsProject.BackEnd.Domain.Entities;

namespace LabsProject.BackEnd.Domain.Repositories
{
    public interface ITestsRepository: IRepositoryBase<Tests>
    {
        void Update(Tests item);
    }
}
