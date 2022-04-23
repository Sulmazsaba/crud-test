using Mc2.CrudTest.Domain.CustomerModule.Contracts;
using System;

namespace Mc2.CrudTest.DomainService.Services
{
    public class EmailCustomerDuplicateChecker : IEmailCustomerDuplicateChecker
    {
        private readonly ICustomerRepository _customerRepository;

        public EmailCustomerDuplicateChecker(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public bool IsEmailCustomerDuplicate(string email, System.Guid customerId)
        {

            return _customerRepository.IsEmailExist(email, customerId);

        }
    }
}
