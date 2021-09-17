using System;
using Flunt.Notifications;
using ModernStore.Domain.Commands;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.Services;
using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Handlers
{
    public class CustomerCommandHandler : Notifiable,
    ICommandHandler<RegisterCustomerCommand>,
    ICommandHandler<UpdateCustumerCommand>
    {
        public readonly ICustomerRepository _customerRepository;
        public readonly IEmailService _emailService;

        public CustomerCommandHandler(ICustomerRepository customerRepository, IEmailService emailService)
        {
            _customerRepository = customerRepository;
            _emailService = emailService;
        }
        public ICommandResult Handle(RegisterCustomerCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Commando inválido", command.Notifications);
            }

            var documentExits = _customerRepository.DocumentExits(command.Document);

            if (documentExits)
            {
                AddNotification("Document", "Documento inválido");
                return new GenericCommandResult(false, "Documento inválido", null);
            }

            var name = new Name(command.FirstName, command.LastName);

            var user = new User(command.Username, command.Password, command.ConfirmPassword);

            var customer = new Customer(name, command.BirthDate, new Email(command.Email), new Document(command.Document), user);

            _customerRepository.Save(customer);

            _emailService.Send(customer.Name.ToString(), customer.Email.Address, "Cliente Cadastrado", "Cliente Cadastrado com sucesso!");

            return new GenericCommandResult(true, "Customer cadastrado com sucesso!", customer);
        }

        public ICommandResult Handle(UpdateCustumerCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                return new GenericCommandResult(false, "Commando inválido", command.Notifications);
            }

            var documentExits = _customerRepository.DocumentExits(command.Document);

            if (documentExits)
            {
                AddNotification("Document", "Documento inválido");
                return new GenericCommandResult(false, "Documento inválido", null);
            }

            var customer = _customerRepository.GetByDocument(command.Document);

            if (customer == null)
            {
                AddNotification("Custumer", "Cliente não encontrado!");
                return new GenericCommandResult(false, "Cliente não encontrado", null);
            }

            var name = new Name(command.FirstName, command.LastName);

            customer.UpdateName(name);
            customer.UpdateEmail(new Email(command.Email));

            _customerRepository.Update(customer);

            _emailService.Send(customer.Name.ToString(), customer.Email.Address, "Cliente atualizado", "Cliente atualizado com sucesso!");

            return new GenericCommandResult(true, "Customer Atualizado com sucesso!", customer);
        }
    }
}