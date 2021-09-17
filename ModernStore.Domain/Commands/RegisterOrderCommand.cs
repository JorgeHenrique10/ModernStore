using System;
using System.Collections.Generic;
using Flunt.Notifications;
using Flunt.Validations;
using ModernStore.Shared.Commands;

namespace ModernStore.Domain.Commands
{
    public class RegisterOrderCommand : Notifiable, ICommand
    {
        public RegisterOrderCommand(Guid customer, decimal deliveryFee, decimal discount, IEnumerable<RegisterOrderItemCommand> items)
        {
            Customer = customer;
            DeliveryFee = deliveryFee;
            Discount = discount;
            Items = items;
        }

        public Guid Customer { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal Discount { get; set; }
        public IEnumerable<RegisterOrderItemCommand> Items { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                .IsNull(Items, "Items", "Não se pode gerar um pedido sem Itens")
            );
        }
    }
}