using System;
using Flunt.Validations;
using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Entities;

namespace ModernStore.Domain.Entities
{
    public class Customer : Entity, IValidatable
    {
        public Customer(Name name, DateTime birthDate, Email email, Document document, User user)
        {
            Name = name;
            BirthDate = birthDate;
            Email = email;
            Document = document;
            User = User;
        }

        public Name Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Email Email { get; private set; }
        public Document Document { get; private set; }
        public User User { get; set; }

        public void Update(Name name, string lastName, DateTime birthDate, Email email)
        {
            Name = name;
            BirthDate = birthDate;
            Email = email;
        }

        public void Validate()
        {
            Name.Validate();
            Email.Validate();
            Document.Validate();

            AddNotifications(Name.Notifications);
            AddNotifications(Email.Notifications);
            AddNotifications(Document.Notifications);
        }
    }
}