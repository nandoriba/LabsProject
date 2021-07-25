using Flunt.Notifications;
using LabsProject.BackEnd.Domain.Commands;
using LabsProject.BackEnd.Domain.Commands.AssociateLabsWithTests;
using LabsProject.BackEnd.Domain.Commands.Contracts;
using LabsProject.BackEnd.Domain.Entities;
using LabsProject.BackEnd.Domain.Handlers.Contracts;
using LabsProject.BackEnd.Domain.Repositories;

namespace LabsProject.BackEnd.Domain.Handlers
{
    public class AssociateLabsWithTestsHandler :
        Notifiable<Notification>, 
        IHandler<CreateAssociateCommand>, 
        IHandler<RemoveAssociateCommand>

    {
        private readonly IAssociateLabsWithTestsRepository _associateLabsWithTestsRepositories;

        public AssociateLabsWithTestsHandler(
            IAssociateLabsWithTestsRepository associateLabsWithTestsRepositories)
        {
            _associateLabsWithTestsRepositories = associateLabsWithTestsRepositories;
        }

        public ICommandResult Handler(CreateAssociateCommand command)
        {
            command.Validate();
            if (command.IsValid)
            {
                return new GenericCommandsResult(
                    false,
                    "Não é possivel realizar a associação",
                    command.Notifications);
            }
            var associateLabsWithTests = new AssociateLabsWithTests(
                command.LaboratoriesId,
                command.TestsId
                );

            _associateLabsWithTestsRepositories.Add(associateLabsWithTests);

            return new GenericCommandsResult(true, "Associação salva com sucesso", associateLabsWithTests);
        }

        public ICommandResult Handler(RemoveAssociateCommand command)
        {
            command.Validate();
            if (command.IsValid)
            {
                return new GenericCommandsResult(
                    false,
                    "Não é possivel realizar a exclusão da associação",
                    command.Notifications);
            }
            var associacao = _associateLabsWithTestsRepositories.GetById(command.Id);

            if (associacao is null)
            {
                return new GenericCommandsResult(
                false,
                "Não é possivel realizar a exclusão da associação",
                null);
            }
            _associateLabsWithTestsRepositories.Remove(command.Id);

            return new GenericCommandsResult(true, "Associação excluida com sucesso", "");
        }
    }
}
