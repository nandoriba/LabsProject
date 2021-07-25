using Flunt.Notifications;
using LabsProject.BackEnd.Domain.Commands;
using LabsProject.BackEnd.Domain.Commands.Contracts;
using LabsProject.BackEnd.Domain.Commands.Tests;
using LabsProject.BackEnd.Domain.Entities;
using LabsProject.BackEnd.Domain.Handlers.Contracts;
using LabsProject.BackEnd.Domain.Repositories;

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
            if (command.IsValid)
            {
                return new GenericCommandsResult(
                    false,
                    "Não é possivel realizar o Cadastro do Teste",
                    command.Notifications);
            } 

            var tests = new Tests(
                    command.Name,
                    command.Type
                );

            _testsRepository.Add(tests);

            return new GenericCommandsResult(true, "Tarefa salva", tests);
        }

        public ICommandResult Handler(RemoveTestsCommand command)
        {
            command.Validate();
            if (command.IsValid)
            {
                return new GenericCommandsResult(
                    false,
                    "Não é possivel realizar o cadastro do Exame",
                    command.Notifications);
            }
            var tests = _testsRepository.GetById(command.Id).Result;

            if (tests is null)
            {
                return new GenericCommandsResult(
                    false,
                    "Não é possivel localizar o cadastro do Exame",
                    command.Notifications);
            }
            tests.RemoveLogicTests();
            _testsRepository.Update(tests);

            return new GenericCommandsResult(true, "Laboratório removido com sucesso", tests);
        }

        public ICommandResult Handler(UpdateTestsCommand command)
        {
            command.Validate();
            if (command.IsValid)
            {
                return new GenericCommandsResult(
                    false,
                    "Não é possivel realizar o cadastro do Exame",
                    command.Notifications);
            }
            var tests = _testsRepository.GetById(command.Id).Result;

            if (tests is null)
            {
                return new GenericCommandsResult(
                    false,
                    "Não é possivel localizar o cadastro do Exame",
                    command.Notifications);
            }           
            _testsRepository.Update(tests);

            return new GenericCommandsResult(true, "Laboratório removido com sucesso", tests);
        }
    }
}
