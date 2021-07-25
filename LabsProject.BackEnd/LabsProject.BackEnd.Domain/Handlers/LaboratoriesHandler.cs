using Flunt.Notifications;
using LabsProject.BackEnd.Domain.Commands;
using LabsProject.BackEnd.Domain.Commands.Contracts;
using LabsProject.BackEnd.Domain.Commands.Laboratories;
using LabsProject.BackEnd.Domain.Entities;
using LabsProject.BackEnd.Domain.Handlers.Contracts;
using LabsProject.BackEnd.Domain.Repositories;
using LabsProject.BackEnd.Domain.ValueObjects;

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
            if (command.IsValid)
            {
                return new GenericCommandsResult(
                    false,
                    "Não é possivel realizar o cadastro do Laboratório",
                    command.Notifications);
            }
            var address = new Address(
                    command.Street,
                    command.Number,
                    command.Neighborhood,
                    command.City,
                    command.State,
                    command.Country,
                    command.ZipCode
                );

            var laboratories = new Laboratories(
                    command.Name, 
                    address
                );

            _laboratoriesRepository.Add(laboratories);

            return new GenericCommandsResult(true, "Tarefa salva", laboratories);
        }

        public ICommandResult Handler(RemoveLaboratoriesCommand command)
        {
            command.Validate();
            if (command.IsValid)
            {
                return new GenericCommandsResult(
                    false,
                    "Não é possivel realizar o cadastro do Laboratório",
                    command.Notifications);
            }
            var laboratories = _laboratoriesRepository.GetById(command.Id).Result;

            if (laboratories is null)
            {
                return new GenericCommandsResult(
                    false,
                    "Não é possivel localizar o cadastro do Laboratório",
                    command.Notifications);
            }
            laboratories.RemoveLogicLaboratories();
            _laboratoriesRepository.Update(laboratories);

            return new GenericCommandsResult(true, "Laboratório removido com sucesso", laboratories);
        }

        public ICommandResult Handler(UpdateLaboratoriesCommand command)
        {
            command.Validate();
            if (command.IsValid)
            {
                return new GenericCommandsResult(
                    false,
                    "Não é possivel realizar o cadastro do Laboratório",
                    command.Notifications);
            }
            var laboratories = _laboratoriesRepository.GetById(command.Id).Result;

            if (laboratories is null)
            {
                return new GenericCommandsResult(
                    false,
                    "Não é possivel localizar o cadastro do Laboratório",
                    command.Notifications);
            }            
            _laboratoriesRepository.Update(laboratories);

            return new GenericCommandsResult(true, "Laboratório atualizado com sucesso", laboratories);
        }
    }
}
