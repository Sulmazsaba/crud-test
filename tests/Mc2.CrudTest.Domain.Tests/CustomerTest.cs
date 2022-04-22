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

        }

        [Fact]
        public void AddCustomer_ShouldReturnCustomerCreatedEvent()
        {
            //var customer = new Customer
            //  //(
            //  //    //id: Guid.NewGuid(),
            //  //    Firstname: "John",
            //  //    lastname: "Snow",
            //  //    dateOfBirth: DateTime.Now.AddYears(-20),
            //  //    email: "JohnSnow@gmail.com",
            //  //    bankAccountNumber: "122233",
            //  //    phoneNumber: "234234234");

           
            //Assert.Single(customer.GetUncommittedEvents());
            //Assert.IsType<CustomerCreatedEvent>(customer.GetUncommittedEvents().First());

        }
    }
}
