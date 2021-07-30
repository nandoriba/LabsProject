using Flunt.Notifications;
using Flunt.Validations;
using LabsProject.BackEnd.Domain.Commands.Contracts;

namespace LabsProject.BackEnd.Domain.Commands.Tests
{
    public class CreateTestsCommand : Notifiable<Notification>, ICommand
    {
        public CreateTestsCommand(string name, string type)
        {
            Name = name;
            Type = type;            
        }
        public CreateTestsCommand() { }

        public string Name { get; set; }
        public string Type { get; set; }        

        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()
                .IsGreaterThan(Name, 3, "Nome", "O Nome do Exame precisar ter pelo menos 3 caracteres")
                );
        }
    }
}
