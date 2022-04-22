using Mc2.CrudTest.Domain.CustomerModule;
using Mc2.CrudTest.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.DomainService.Services
{
    internal class CustomerDuplicateChecker : ICustomerDuplicateChecker
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerDuplicateChecker(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void CheckCustomerDuplicated(Guid customerId, string firstName, string lastName, DateTime dateOfBirth)
        {
            var isDuplicated = _customerRepository.IsCustomerExist(customerId, firstName, lastName, dateOfBirth);
            if (isDuplicated)
                throw new DomainException("Customer is duplicated");
        }
    }
}
