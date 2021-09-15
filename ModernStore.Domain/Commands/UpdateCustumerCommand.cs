using System;
using Flunt.Notifications;
using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commands
{
    public class UpdateCustumerCommand : Notifiable, ICommand
    {
        public UpdateCustumerCommand(string firstName, string lastName, string email, string document, string username, string password, string confirmPassword, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Document = document;
            Username = username;
            Password = password;
            ConfirmPassword = confirmPassword;
            BirthDate = birthDate;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Document { get; private set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; private set; }
    }
}