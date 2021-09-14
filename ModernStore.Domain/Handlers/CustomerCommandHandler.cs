using System;
using Flunt.Notifications;
using ModernStore.Domain.Commands;
using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Handlers
{
    public class CustomerCommandHandler : Notifiable, ICommandHandler<RegisterCustomerCommand>
    {
        public ICommandResult Handle(RegisterCustomerCommand command)
        {
            var name = new Name(command.firstName, command.lastName);
            var email = new Email(command.Email);
            var cpf = new Document(command.Document);
            var user = new User(command.Username, command.Password);

            var customer = new Customer(name, DateTime.Now, email, cpf, user);



            throw new System.NotImplementedException();
        }
    }
}