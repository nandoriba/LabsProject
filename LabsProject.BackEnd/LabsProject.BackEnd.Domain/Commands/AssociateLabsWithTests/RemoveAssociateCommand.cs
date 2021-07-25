using Flunt.Notifications;
using Flunt.Validations;
using LabsProject.BackEnd.Domain.Commands.Contracts;
using System;

namespace LabsProject.BackEnd.Domain.Commands.AssociateLabsWithTests
{
    public class RemoveAssociateCommand : Notifiable<Notification>, ICommand
    {
        public RemoveAssociateCommand(Guid id)
        {
            Id = id;
        }
        public RemoveAssociateCommand() { }

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
