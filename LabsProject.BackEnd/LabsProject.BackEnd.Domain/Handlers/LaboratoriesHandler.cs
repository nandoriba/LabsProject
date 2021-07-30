using Flunt.Notifications;
using LabsProject.BackEnd.Domain.Commands;
using LabsProject.BackEnd.Domain.Commands.Contracts;
using LabsProject.BackEnd.Domain.Commands.Laboratories;
using LabsProject.BackEnd.Domain.Entities;
using LabsProject.BackEnd.Domain.Handlers.Contracts;
using LabsProject.BackEnd.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace LabsProject.BackEnd.Domain.Handlers
{
    public class LaboratoriesHandler :
        Notifiable<Notification>, 
        IHandler<CreateLaboratoriesCommand>, 
        IHandler<UpdateLaboratoriesCommand>, 
        IHandler<RemoveLaboratoriesCommand>
    {
        private readonly ILaboratoriesRepository _laboratoriesRepository;

        public LaboratoriesHandler(
            ILaboratoriesRepository laboratoriesRepository)
        {
            _laboratoriesRepository = laboratoriesRepository;
        }

        public ICommandResult Handler(CreateLaboratoriesCommand command)
        {
            command.Validate();
            if (!command.IsValid)
            {
                return new GenericCommandsResult(
                    false,
                    "Não é possivel realizar o cadastro do Laboratório",
                    command.Notifications);
            }           

            var laboratories = new Laboratories(
                    Guid.NewGuid(),
                    command.Name, 
                    command.Address
                );

            _laboratoriesRepository.Add(laboratories);

            return new GenericCommandsResult(true, "Laboratório cadastrado com sucesso", laboratories);
        }
        public IEnumerable<ICommandResult> Handler(IEnumerable<CreateLaboratoriesCommand> collectionCommand)
        {
            var newCollectionResult = new List<GenericCommandsResult>();

            foreach (var command in collectionCommand)
            {
                newCollectionResult.Add((GenericCommandsResult)Handler(command));
            }
            return newCollectionResult;
        }

        public ICommandResult Handler(RemoveLaboratoriesCommand command)
        {
            command.Validate();
            if (!command.IsValid)
            {
                return new GenericCommandsResult(
                    false,
                    "Não foi possivel realizar a exclusão do Laboratório",
                    command.Notifications);
            }
            var laboratories = _laboratoriesRepository.GetById(command.Id)
                        .GetAwaiter().GetResult();

            if (laboratories is null)
            {
                return new GenericCommandsResult(
                    false,
                    "Não foi possivel localizar o cadastro do Laboratório informado",
                    command.Notifications);
            }
            laboratories.RemoveLogicLaboratories();
            _laboratoriesRepository.Update(laboratories);

            return new GenericCommandsResult(true, "Laboratório excluido com sucesso", laboratories);
        }
        public IEnumerable<ICommandResult> Handler(IEnumerable<RemoveLaboratoriesCommand> collectionCommand)
        {
            var newCollectionResult = new List<GenericCommandsResult>();

            foreach (var command in collectionCommand)
            {
                newCollectionResult.Add((GenericCommandsResult)Handler(command));
            }
            return newCollectionResult;
        }

        public ICommandResult Handler(UpdateLaboratoriesCommand command)
        {
            command.Validate();
            if (!command.IsValid)
            {
                return new GenericCommandsResult(
                    false,
                    "Não é possivel realizar a atualização do Laboratório",
                    command.Notifications);
            }
            var laboratories = _laboratoriesRepository.GetById(command.Id)  
                                .GetAwaiter().GetResult();

            if (laboratories is null)
            {
                return new GenericCommandsResult(
                    false,
                    "Não é possivel realizar a atualização do Laboratório",
                    command.Notifications);
            }

            var upLaboratories = new Laboratories(
                id: command.Id, 
                name: command.Name, 
                address: command.Address
                );
            _laboratoriesRepository.Update(upLaboratories);

            return new GenericCommandsResult(true, "Laboratório atualizado com sucesso", upLaboratories);
        }
        public IEnumerable<ICommandResult> Handler(IEnumerable<UpdateLaboratoriesCommand> collectionCommand)
        {
            var newCollectionResult = new List<GenericCommandsResult>();

            foreach (var command in collectionCommand)
            {
                newCollectionResult.Add((GenericCommandsResult)Handler(command));
            }
            return newCollectionResult;
        }
    }
}
