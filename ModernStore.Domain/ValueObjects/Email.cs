using Flunt.Notifications;
using Flunt.Validations;

namespace ModernStore.Domain.ValueObjects
{
    public class Email : Notifiable, IValidatable
    {
        public Email(string address)
        {
            Address = address;
        }

        public string Address { get; private set; }
        public void Validate()
        {
            AddNotifications(
                 new Contract()
                     .Requires()
                     .HasMaxLen(Address, 60, "Email", "Email Nome Inválido")
                     .HasMinLen(Address, 3, "Email", "Email Nome Inválido")
             );
        }
    }
}