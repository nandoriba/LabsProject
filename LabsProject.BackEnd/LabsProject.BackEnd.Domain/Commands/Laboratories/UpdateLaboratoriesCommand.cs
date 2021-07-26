using Flunt.Notifications;
using Flunt.Validations;
using LabsProject.BackEnd.Domain.Commands.Contracts;
using System;

namespace LabsProject.BackEnd.Domain.Commands.Laboratories
{
    public class UpdateLaboratoriesCommand : Notifiable<Notification>, ICommand
    {
        public UpdateLaboratoriesCommand() { }

        public UpdateLaboratoriesCommand(Guid id, string name, string address)
        {
            Id = id;
            Name = name;
            Address = address;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }       

        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsGreaterThan(Name, 3, "Nome", "O Nome do Laboratório precisar ter pelo menos 3 caracteres")
                .IsGreaterThan(Address, 3, "Rua", "O Nome precisar ter pelo menos 3 caracteres")               
                );
        }
    }
}
