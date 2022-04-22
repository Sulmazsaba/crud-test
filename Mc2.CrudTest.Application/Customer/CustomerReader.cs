using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Customer
{
    public class CustomerReader : ICustomerReader
    {
        public Task<IEnumerable<CustomerDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerDto> GetById(Guid customerId)
        {
            throw new NotImplementedException();
        }
    }
}
