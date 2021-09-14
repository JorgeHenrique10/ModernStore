using Flunt.Notifications;
using Flunt.Validations;

namespace ModernStore.Domain.ValueObjects
{
    public class Name : Notifiable, IValidatable
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public void Validate()
        {
            AddNotifications(
                 new Contract()
                     .Requires()
                     .HasMaxLen(FirstName, 60, "FirstName", "Primeiro Nome Inválido")
                     .HasMinLen(FirstName, 3, "FirstName", "Primeiro Nome Inválido")
                     .HasMaxLen(LastName, 60, "LastName", "Ultimo Nome Inválido")
                     .HasMinLen(LastName, 3, "LastName", "Ultimo Nome Inválido")
             );
        }
    }
}