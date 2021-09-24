using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ModernStore.Domain.Commands.Queries;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Contexts;

namespace ModernStore.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ModernStoreDataContext _context;
        public CustomerRepository(ModernStoreDataContext context)
        {
            _context = context;
        }
        public bool DocumentExits(string document)
        {
            return _context.Customers.Any(x => x.Document.Number == document);
        }

        public Customer Get(Guid id)
        {
            return _context.Customers.Include(x => x.User).FirstOrDefault(x => x.Id == id);
        }

        public CustomerComandQueries Get(string userName)
        {
            return _context.Customers
                .AsNoTracking()
                .Include(x => x.User)
                .Select(x => new CustomerComandQueries(x.Name.ToString(), x.Document.Number, x.Email.Address, x.User.UserName, x.User.Password, x.User.Active))
                .FirstOrDefault(x => x.UserName == userName);

        }

        public Customer GetByAuthentication(string username, string password)
        {
            return _context.Customers.Include(x => x.User).FirstOrDefault(x => x.User.UserName == username && x.User.Password == password);
        }

        public Customer GetByDocument(string document)
        {
            return _context.Customers.Include(x => x.User).FirstOrDefault(x => x.Document.Number == document);
        }

        public Customer GetByUserId(Guid id)
        {
            return _context.Customers.Include(x => x.User).FirstOrDefault(x => x.Id == id);
        }

        public void Save(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public void Update(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }
    }
}