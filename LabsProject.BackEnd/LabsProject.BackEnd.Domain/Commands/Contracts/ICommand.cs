using Flunt.Validations;


namespace LabsProject.BackEnd.Domain.Commands.Contracts
{
    public interface ICommand
    {
        void Validate();
    }
}
