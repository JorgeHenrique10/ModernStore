using System;
using Flunt.Notifications;
using Flunt.Validations;

namespace ModernStore.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

    }
}