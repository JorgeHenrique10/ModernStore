using Flunt.Notifications;
using Flunt.Validations;
using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commands
{
    public class AuthenticateCommand : Notifiable, ICommand
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public void Validate()
        {
            AddNotifications(
                new Contract()
                .Requires()
                .IsNotNull(UserName, "UserName", "O campo não pode ser vazio!")
                .IsNotNull(Password, "Password", "O campo não pode ser vazio!")
            );

        }
    }
}