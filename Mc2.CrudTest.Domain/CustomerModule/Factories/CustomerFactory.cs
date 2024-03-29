﻿using Mc2.CrudTest.Domain.CustomerModule.Commands;
using Mc2.CrudTest.Domain.CustomerModule.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.CustomerModule.Factories
{
    public class CustomerFactory : ICustomerFactory
    {

        private readonly ICustomerDuplicateChecker _duplicateChecker;
        private readonly IEmailCustomerDuplicateChecker _emailCustomerDuplicateChecker;

        public CustomerFactory(ICustomerDuplicateChecker duplicateChecker,
            IEmailCustomerDuplicateChecker emailCustomerDuplicateChecker)
        {
            _duplicateChecker = duplicateChecker;
            _emailCustomerDuplicateChecker = emailCustomerDuplicateChecker;
        }

        public Customer Create(AddCustomerCommand customerCommand)
        {
            var id = Guid.NewGuid();
            _duplicateChecker.CheckCustomerDuplicated(id, customerCommand.Firstname, customerCommand.Lastname, customerCommand.DateOfBirth);

            var customer = new Customer(customerCommand.ToInitializerArgument(id));
            customer.CheckIfEmailIsValid(customerCommand.Email, _emailCustomerDuplicateChecker);
            customer.CheckIfPhoneNumberIsValid(customerCommand.PhoneNumber);

            return customer;
        }
    }
}
