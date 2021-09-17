using System;
using Flunt.Notifications;
using Flunt.Validations;
using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commands
{
    public class RegisterCustomerCommand : Notifiable, ICommand
    {
        public RegisterCustomerCommand(string firstName, string lastName, string email, string document, string username, string password, string confirmPassword, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            Document = document;
            Username = username;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Document { get; private set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; private set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .HasMinLen(Email, 3, "Email", "O Email não pode conter menos de 3 caracteres")
                .HasMinLen(FirstName, 3, "FirstName", "Primeiro nome inválido")
                .HasMinLen(FirstName, 3, "LasttName", "Último nome inválido")
            );
        }
    }
}