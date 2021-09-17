using System;
using Flunt.Notifications;
using Flunt.Validations;
using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commands
{
    public class RegisterOrderItemCommand : Notifiable, ICommand
    {
        public RegisterOrderItemCommand(Guid product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public Guid Product { get; set; }
        public int Quantity { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .IsGreaterThan(Quantity, 0, "Quantity", "Valor tem que ser maior que zero")
            );
        }
    }
}