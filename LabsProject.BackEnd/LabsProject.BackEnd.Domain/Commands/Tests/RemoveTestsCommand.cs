using System;
using Flunt.Notifications;
using Flunt.Validations;
using LabsProject.BackEnd.Domain.Commands.Contracts;

namespace LabsProject.BackEnd.Domain.Commands.Tests
{
    public class RemoveTestsCommand : Notifiable<Notification>, ICommand
    {
        public RemoveTestsCommand(Guid id)
        {
            Id = id;
        }
        public RemoveTestsCommand() { }

        public Guid Id { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotEmpty(Id, "Id", "O Campo Id precisa ser preenchido")
                );
        }
    }
}
