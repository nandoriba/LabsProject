using LabsProject.BackEnd.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace LabsProject.BackEnd.Domain.Commands.AssociateLabsWithTests
{
    public class CreateAssociateCommand : Notifiable<Notification>, ICommand
    {
        public Guid LaboratoriesId { get; private set; }
        public Guid TestsId { get; private set; }

        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsNotEmpty(LaboratoriesId, "LaboratoriesId", "O Campo Id do Laboratório não pode ser vazio")
                .IsNotEmpty(TestsId, "TestsId", "O Campo Id do Exame não pode ser vazio")
                );
        }
    }
}
