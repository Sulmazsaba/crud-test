using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.CustomerModule
{
    public interface ICustomerDuplicateChecker
    {
        void CheckCustomerDuplicated(Guid customerId, string firstName, string lastName, DateTime dateOfBirth);
    }
}
