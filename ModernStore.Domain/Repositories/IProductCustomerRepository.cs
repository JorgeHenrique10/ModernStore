using System;
using ModernStore.Domain.Entities;

namespace ModernStore.Domain.Repositories
{
    public interface IProductCustomerRepository
    {
        Product Get(Guid id);
    }
}