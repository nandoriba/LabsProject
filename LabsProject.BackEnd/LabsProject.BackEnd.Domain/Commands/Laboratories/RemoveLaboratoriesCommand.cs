using System;
using Flunt.Notifications;
using Flunt.Validations;
using LabsProject.BackEnd.Domain.Commands.Contracts;

namespace LabsProject.BackEnd.Domain.Commands.Laboratories
{
    public class RemoveLaboratoriesCommand : Notifiable<Notification>, ICommand
    {
        public RemoveLaboratoriesCommand(Guid id)
        {
            Id = id;
        }
        public RemoveLaboratoriesCommand() { }

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
