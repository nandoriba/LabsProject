using LabsProject.BackEnd.Domain.Entities;

namespace LabsProject.BackEnd.Domain.Repositories
{
    public interface ILaboratoriesRepository: IRepositoryBase<Laboratories>
    {
        void Update(Laboratories item);
    }
}
