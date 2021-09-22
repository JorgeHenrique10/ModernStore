using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ModernStore.Domain.Commands.Queries;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Contexts;

namespace ModernStore.Infra.Repositories
{
    public class ProductCustomerRepository : IProductCustomerRepository
    {
        private readonly ModernStoreDataContext _context;
        public ProductCustomerRepository(ModernStoreDataContext context)
        {
            _context = context;

        }

        public Product Get(Guid id)
        {
            return _context.Products.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<ProductCustomerListCommandQuery> Get()
        {
            return _context.Products.AsNoTracking().Select(x => new ProductCustomerListCommandQuery(x.Id, x.Title, x.Price, x.Image)).ToArray();
        }
    }
}