using System;
using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commands
{
    public class RegisterCustomerCommand : ICommand
    {
        public RegisterCustomerCommand(string firstName, string lastName, string email, string document, string username, string password, string confirmPassword, string birthDate)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            Email = email;
            BirthDate = birthDate;
            Document = document;
            Username = username;
            Password = password;
            ConfirmPassword = confirmPassword;
        }

        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public string Email { get; private set; }
        public string BirthDate { get; private set; }
        public string Document { get; private set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; private set; }
    }
}