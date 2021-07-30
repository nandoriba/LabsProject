using Flunt.Notifications;
using LabsProject.BackEnd.Domain.Commands;
using LabsProject.BackEnd.Domain.Commands.Contracts;
using LabsProject.BackEnd.Domain.Commands.Tests;
using LabsProject.BackEnd.Domain.Entities;
using LabsProject.BackEnd.Domain.Handlers.Contracts;
using LabsProject.BackEnd.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace LabsProject.BackEnd.Domain.Handlers
{
    public class TestsHandler : Notifiable<Notification>, 
        IHandler<CreateTestsCommand>, 
        IHandler<RemoveTestsCommand>, 
        IHandler<UpdateTestsCommand>
    {
        private readonly ITestsRepository _testsRepository;

        public TestsHandler(ITestsRepository testsRepository)
        {
            _testsRepository = testsRepository;
        }

        public ICommandResult Handler(CreateTestsCommand command)
        {
            command.Validate();
            if (!command.IsValid)
            {
                return new GenericCommandsResult(
                    false,
                    "Não é possivel adicionar o Exame",
                    command.Notifications);
            } 

            var tests = new Tests(
                    Guid.NewGuid(),
                    command.Name,
                    command.Type
                );

            _testsRepository.Add(tests);

            return new GenericCommandsResult(true, "Tarefa salva", tests);
        }
        public IEnumerable<ICommandResult> Handler(IEnumerable<CreateTestsCommand> collectionCommand)
        {
            var newCollectionResult = new List<GenericCommandsResult>();

            foreach (var command in collectionCommand)
            {
                newCollectionResult.Add((GenericCommandsResult)Handler(command));
            }
            return newCollectionResult;
        }

        public ICommandResult Handler(RemoveTestsCommand command)
        {
            command.Validate();
            if (!command.IsValid)
            {
                return new GenericCommandsResult(
                    false,
                    "Não é possivel remover o Exame",
                    command.Notifications);
            }
            var tests = _testsRepository.GetById(command.Id).GetAwaiter().GetResult();

            if (tests is null)
            {
                return new GenericCommandsResult(
                    false,
                    "Não foi possivel localizar o cadastro de Exame para exclusão",
                    command.Notifications);
            }
            tests.RemoveLogicTests();
            _testsRepository.Update(tests);

            return new GenericCommandsResult(true, "Exame removido com sucesso", tests);
        }
        public IEnumerable<ICommandResult> Handler(IEnumerable<RemoveTestsCommand> collectionCommand)
        {
            var newCollectionResult = new List<GenericCommandsResult>();

            foreach (var command in collectionCommand)
            {
                newCollectionResult.Add((GenericCommandsResult)Handler(command));
            }
            return newCollectionResult;
        }

        public ICommandResult Handler(UpdateTestsCommand command)
        {
            command.Validate();
            if (!command.IsValid)
            {
                return new GenericCommandsResult(
                    false,
                    "Não é possivel realizar a atualização do Exame",
                    command.Notifications);
            }
            var tests = _testsRepository.GetById(command.Id).GetAwaiter().GetResult();

            if (tests is null)
            {
                return new GenericCommandsResult(
                    false,
                    "Não é possivel localizar o cadastro do Exame para atualizar",
                    command.Notifications);
            }
            var upTest = new Tests(
                id: command.Id, 
                name: command.Name, 
                type: command.Type
                );
            _testsRepository.Update(upTest);

            return new GenericCommandsResult(true, "Laboratório atualizado com sucesso", upTest);
        }
        public IEnumerable<ICommandResult> Handler(IEnumerable<UpdateTestsCommand> collectionCommand)
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
