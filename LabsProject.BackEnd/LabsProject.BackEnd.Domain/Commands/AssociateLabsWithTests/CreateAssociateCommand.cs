using LabsProject.BackEnd.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace LabsProject.BackEnd.Domain.Commands.AssociateLabsWithTests
{
    public class CreateAssociateCommand : Notifiable<Notification>, ICommand
    {
        public CreateAssociateCommand(Guid laboratoriesId, Guid testsId)
        {
            LaboratoriesId = laboratoriesId;
            TestsId = testsId;
        }

        public Guid LaboratoriesId { get; set; }
        public Guid TestsId { get; set; }

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
