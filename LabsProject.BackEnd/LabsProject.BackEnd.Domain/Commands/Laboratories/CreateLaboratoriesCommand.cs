﻿using LabsProject.BackEnd.Domain.Commands.Contracts;
using Flunt.Notifications;
using Flunt.Validations;

namespace LabsProject.BackEnd.Domain.Commands.Laboratories
{
    public class CreateLaboratoriesCommand: Notifiable<Notification>, ICommand
    {
        public CreateLaboratoriesCommand() { }

        public CreateLaboratoriesCommand(string name, string street, string number, 
                                         string neighborhood, string city, string state, 
                                         string country, string zipCode, int stateId)
        {
            Name = name;
            Street = street;
            Number = number;
            Neighborhood = neighborhood;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
            StateId = stateId;
        }

        public string Name { get;  set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public int StateId { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract<Notification>()
                .Requires()                
                .IsGreaterThan(Name, 3, "Nome", "O Nome do Laboratório precisar ter pelo menos 3 caracteres")
                .IsGreaterThan(Street, 3, "Rua", "O Nome precisar ter pelo menos 3 caracteres")
                .IsGreaterThan(Neighborhood, 3, "Bairro", "O Nome precisar ter pelo menos 3 caracteres")
                .IsGreaterThan(City, 3, "Cidade", "O Nome precisar ter pelo menos 3 caracteres")
                .AreEquals(State, 2, "UF", "O UF precisa ter 2 carácteres")
                .IsGreaterThan(Country, 3, "País", "O País precisar ter pelo menos 3 caracteres")
                );
        }
    }
}