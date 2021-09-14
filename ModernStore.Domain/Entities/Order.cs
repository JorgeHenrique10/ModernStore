using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using ModernStore.Domain.Enums;
using ModernStore.Shared.Entities;

namespace ModernStore.Domain.Entities
{
    public class Order : Entity, IValidatable
    {
        private readonly IList<OrderItem> _items;

        public Order(Customer customer, decimal deliveryFee, decimal discount)
        {
            Customer = customer;
            CreateDate = DateTime.Now;
            Number = Guid.NewGuid().ToString().Substring(0, 8);
            Status = EOrderStatus.Created;
            DeliveryFee = deliveryFee;
            Discount = discount;

            _items = new List<OrderItem>();

        }
        public Customer Customer { get; private set; }
        public DateTime CreateDate { get; private set; }
        public string Number { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public decimal DeliveryFee { get; private set; }
        public decimal Discount { get; private set; }

        public decimal SubTotal => Items.Sum(x => x.Total());
        public decimal Total => SubTotal + DeliveryFee - Discount;

        public void AddItem(OrderItem item)
        {
            if (item.Valid)
                _items.Add(item);
        }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsGreaterThan(DeliveryFee, 0, "DeliveryFee", "DeliveryFee inválido")
                    .IsGreaterThan(Discount, -1, "Discount", "Discount inválido")
            );
        }
    }
}