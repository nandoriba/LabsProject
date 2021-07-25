using LabsProject.BackEnd.Domain.Commands.Contracts;

namespace LabsProject.BackEnd.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handler(T command);
    }
}
