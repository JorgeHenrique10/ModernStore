using Flunt.Validations;
using ModernStore.Shared.Entities;

namespace ModernStore.Domain.Entities
{
    public class OrderItem : Entity, IValidatable
    {
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = Product.Price;

            product.DecreaseQuantity(quantity);
        }

        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public decimal Total() => Price * Quantity;

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsGreaterThan(Quantity, 1, "Quantity", "Quantidade inválida")
                    .IsGreaterThan(Product.QuantityOnHand, Quantity + 1, "Quantity", "Quantidade maior que o estoque")
            );
        }
    }
}