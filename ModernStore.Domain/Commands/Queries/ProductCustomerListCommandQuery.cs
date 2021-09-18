using System;

namespace ModernStore.Domain.Commands.Queries
{
    public class ProductCustomerListCommandQuery
    {
        public ProductCustomerListCommandQuery(Guid id, string title, decimal price, string image)
        {
            Id = id;
            Title = title;
            Price = price;
            Image = image;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}