using Mc2.CrudTest.Domain.CustomerModule;
using Mc2.CrudTest.Domain.CustomerModule.Contracts;
using Mc2.CrudTest.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Infrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Mc2DbContext _dbcontext;

        public CustomerRepository(Mc2DbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<Customer> AddAsync(Customer entity)
        {
            await _dbcontext.Customers.AddAsync(entity);
            await _dbcontext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(Customer entity)
        {
            _dbcontext.Customers.Remove(entity);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _dbcontext.Customers.ToListAsync();
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            return await _dbcontext.FindAsync<Customer>(id);
        }

        public bool IsCustomerExist(Guid customerId, string firstName, string lastName, DateTime dateOfBirth)
        {
            return _dbcontext.Customers.Any(i => i.Id != customerId && i.Firstname == firstName && i.Lastname == lastName && i.DateOfBirth == dateOfBirth);
        }

        public bool IsEmailExist(string email, Guid customerId)
        {
            return _dbcontext.Customers.Any(i => i.Email == email && i.Id != customerId);
        }

        public async Task UpdateAsync(Customer entity)
        {

            _dbcontext.Entry(entity).State = EntityState.Modified;

            await _dbcontext.SaveChangesAsync();

        }
    }
}
