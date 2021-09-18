using System;
using System.Collections.Generic;
using ModernStore.Domain.Commands.Queries;
using ModernStore.Domain.Entities;

namespace ModernStore.Domain.Repositories
{
    public interface IProductCustomerRepository
    {
        Product Get(Guid id);
        IEnumerable<ProductCustomerListCommandQuery> Get();
    }
}