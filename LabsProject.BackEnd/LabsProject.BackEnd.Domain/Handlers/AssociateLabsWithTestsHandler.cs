using Flunt.Notifications;
using LabsProject.BackEnd.Domain.Commands;
using LabsProject.BackEnd.Domain.Commands.AssociateLabsWithTests;
using LabsProject.BackEnd.Domain.Commands.Contracts;
using LabsProject.BackEnd.Domain.Entities;
using LabsProject.BackEnd.Domain.Handlers.Contracts;
using LabsProject.BackEnd.Domain.Repositories;
using LabsProject.BackEnd.Domain.ValueObjects;
using System;

namespace LabsProject.BackEnd.Domain.Handlers
{
    public class AssociateLabsWithTestsHandler :
        Notifiable<Notification>, 
        IHandler<CreateAssociateCommand>, 
        IHandler<RemoveAssociateCommand>

    {
        private readonly IAssociateLabsWithTestsRepository _associateLabsWithTestsRepositories;
        private readonly ILaboratoriesRepository _laboratoriesRepository;
        private readonly ITestsRepository _testsRepository;

        public AssociateLabsWithTestsHandler(
            IAssociateLabsWithTestsRepository associateLabsWithTestsRepositories, 
            ILaboratoriesRepository laboratoriesRepository, 
            ITestsRepository testsRepository)
        {
            _associateLabsWithTestsRepositories = associateLabsWithTestsRepositories;
            _laboratoriesRepository = laboratoriesRepository;
            _testsRepository = testsRepository;
        }

        public ICommandResult Handler(CreateAssociateCommand command)
        {
            command.Validate();
            if (!command.IsValid)
            {
                return new GenericCommandsResult(
                    false,
                    "Não é possivel realizar a associação",
                    command.Notifications);
            }

            var laboratories = _laboratoriesRepository.GetById(command.LaboratoriesId)
                .GetAwaiter().GetResult();

            if (laboratories is null)
            {
                return new GenericCommandsResult(
                    false,
                    "Não é possivel realizar a associação, laboratório não encontrado",
                    command.Notifications);
            }           

            var tests = _testsRepository.GetById(command.TestsId)
                .GetAwaiter().GetResult(); 

            if (tests is null)
            {
                return new GenericCommandsResult(
                    false,
                    "Não é possivel realizar a associação, exame não encontrado",
                    command.Notifications);
            }                         

            var associateLabsWithTests = new AssociateLabsWithTests(
                Guid.NewGuid(),
                command.LaboratoriesId,
                command.TestsId
                );

            _associateLabsWithTestsRepositories.Add(associateLabsWithTests);

            return new GenericCommandsResult(true, "Associação salva com sucesso", associateLabsWithTests);
        }

        public ICommandResult Handler(RemoveAssociateCommand command)
        {
            command.Validate();
            if (!command.IsValid)
            {
                return new GenericCommandsResult(
                    false,
                    "Não é possivel realizar a exclusão da associação",
                    command.Notifications);
            }
            var associacao = _associateLabsWithTestsRepositories.GetById(command.Id)
                .GetAwaiter().GetResult();

            if (associacao is null)
            {
                return new GenericCommandsResult(
                false,
                "Não foi possivel localizar a associação para exclusão",
                null);
            }
            _associateLabsWithTestsRepositories.Remove(associacao);

            return new GenericCommandsResult(true, "Associação excluida com sucesso", "");
        }        
    }
}
