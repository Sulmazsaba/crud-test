using Mc2.CrudTest.Domain.Core;
using Mc2.CrudTest.Domain.CustomerModule;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Mc2.CrudTest.Domain.Tests
{
    public class CustomerTest
    {
        private readonly CustomerInitializerArgument initializerArgument;
        public CustomerTest()
        {
            initializerArgument = new CustomerInitializerArgument
            {
                CustomerId = Guid.NewGuid(),
                Firstname = "John",
                Lastname = "Snow",
                DateOfBirth = DateTime.Now.AddYears(-20),
                Email = "JohnSnow@gmail.com",
                BankAccountNumber = "122233",
                PhoneNumber = "234234234"
            };


        }

        [Fact]
        public void AddCustomer_ShouldReturnCustomerCreatedEvent()
        {
            var customer = new Customer(initializerArgument);


            Assert.Single(customer.GetUncommittedEvents());
            //Assert.IsType<CustomerCreatedEvent>(customer.GetUncommittedEvents().First());

        }
    }
}
