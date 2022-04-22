using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Customer
{
    public interface ICustomerReader
    {
        Task<CustomerDto> GetById(Guid customerId);
        Task<IEnumerable<CustomerDto>> GetAll();
    }
}
