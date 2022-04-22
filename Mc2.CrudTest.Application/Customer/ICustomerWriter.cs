using Mc2.CrudTest.Domain.CustomerModule;
using Mc2.CrudTest.Domain.CustomerModule.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Customer
{
    public interface ICustomerWriter
    {
        Task<CustomerDto> AddCustomer(AddCustomerCommand command);

        Task UpdateCustomer(UpdateCustomerCommand command);

        Task DeleteCustomer(DeleteCustomerCommand customerId);   
    }
}
