using Flunt.Notifications;
using Flunt.Validations;
using LabsProject.BackEnd.Domain.Commands.Contracts;
using System;

namespace LabsProject.BackEnd.Domain.Commands.Tests
{
    public class UpdateTestsCommand: Notifiable<Notification>, ICommand
    {
        public UpdateTestsCommand(Guid id, string name, string type)
        {
            Id = id;
            Name = name;
            Type = type;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public void Validate()
        {
            AddNotifications(
            new Contract<Notification>()
            .Requires()
            .IsNotEmpty(Id, "Id", "O Campo Id precisa ser preenchido")
            .IsGreaterThan(Name, 3, "Nome", "O Nome do Exame precisar ter pelo menos 3 caracteres")
            );
        }
    }
}
