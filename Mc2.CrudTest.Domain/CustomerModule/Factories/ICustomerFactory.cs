using Mc2.CrudTest.Domain.CustomerModule.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.CustomerModule.Factories
{
    public interface ICustomerFactory
    {
        Customer Create(AddCustomerCommand customerCommand);
    }
}
