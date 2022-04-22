using Mc2.CrudTest.Domain.CustomerModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.Persistence
{
    public interface IRepository
    {
        Task<Customer> GetByIdAsync(Guid id);
        Task<Customer> AddAsync(Customer entity);

        Task SaveAsync(Customer customer);
    }
}
