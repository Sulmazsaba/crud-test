using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.CustomerModule.Contracts
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(Guid id);
        Task<Customer> AddAsync(Customer entity);

        Task UpdateAsync(Customer entity);
        Task DeleteAsync(Customer entity);

        Task<List<Customer>> GetAllAsync();

        bool IsEmailExist(string email, Guid customerId);

        bool IsCustomerExist(Guid customerId, string firstName, string lastName, DateTime dateOfBirth);
    }
}
