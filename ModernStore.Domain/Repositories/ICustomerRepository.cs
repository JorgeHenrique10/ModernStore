using System;
using ModernStore.Domain.Entities;

namespace ModernStore.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(Guid id);
        Customer GetByUserId(Guid id);
        Customer GetByDocument(string document);
        void Update(Customer customer);
        void Save(Customer customer);
        bool DocumentExits(string document);
    }
}