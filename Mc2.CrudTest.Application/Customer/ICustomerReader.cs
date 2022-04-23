using Mc2.CrudTest.Domain.CustomerModule;
using Mc2.CrudTest.Domain.CustomerModule.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Customer
{
    public interface ICustomerReader
    {
        Task<CustomerDto> GetById(GetCustomerByIdQuery getCustomerByIdQuery);
        Task<IEnumerable<CustomerDto>> GetAll();
    }
}
