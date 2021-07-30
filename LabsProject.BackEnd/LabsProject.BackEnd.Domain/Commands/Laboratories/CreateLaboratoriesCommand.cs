using LabsProject.BackEnd.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace LabsProject.BackEnd.Domain.Commands.Laboratories
{
    public class CreateLaboratoriesCommand: Notifiable<Notification>, ICommand
    {
        public CreateLaboratoriesCommand() { }

        public CreateLaboratoriesCommand(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public string Name { get;  set; }
        public string Address { get; set; }       

        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()                
                .IsGreaterThan(Name, 3, "Nome", "O Nome do Laboratório precisar ter pelo menos 3 caracteres")
                .IsGreaterThan(Address, 3, "Endereco", "O Endereco precisar ter pelo menos 3 caracteres")      
                );
        }
    }
}
