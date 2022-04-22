using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.CustomerModule.Queries
{
    public class GetCustomerListQuery : Request<IEnumerable<Customer>>
    {
    }
}
