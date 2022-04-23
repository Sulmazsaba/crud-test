using FluentAssertions;
using Mc2.CrudTest.Domain.CustomerModule;
using Mc2.CrudTest.Infrastructure.Persistence;
using Mc2.CrudTest.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.Infrastructure.Tests
{
    public class CustomerRepositoryTests
    {
        private Customer customer;
        public CustomerRepositoryTests()
        {
            var initializer = new CustomerInitializerArgument
            {
                Firstname = "John",
                Lastname = "Snow",
                DateOfBirth = DateTime.Now.AddYears(-20),
                Email = "JohnSnow@gmail.com",
                BankAccountNumber = "122233",
                PhoneNumber = "234234234"
            };

            customer = new Customer(initializer);
        }


        [Fact]
        public async Task FindCustomerById_ShouldReturnCorrectValue()
        {

            var dbOptions = new DbContextOptionsBuilder<Mc2DbContext>().UseInMemoryDatabase("FindByIdTest").Options;

            using var context = new Mc2DbContext(dbOptions);

            var customerRepository = new CustomerRepository(context);



            await customerRepository.AddAsync(customer);

            var result = await customerRepository.GetByIdAsync(customer.Id);

            result.Id.Should().Be(customer.Id);
            result.Firstname.Should().Be(customer.Firstname);
            result.Lastname.Should().Be(customer.Lastname);
            result.PhoneNumber.Should().Be(customer.PhoneNumber);
            result.Email.Should().Be(customer.Email);
            result.BankAccountNumber.Should().Be(customer.BankAccountNumber);

        }

        [Fact]
        public async Task IsEmailExist_ShouldReturnCorrectValue()
        {
            var dbOptions = new DbContextOptionsBuilder<Mc2DbContext>().UseInMemoryDatabase("IsEmailExistTest").Options;

            using var context = new Mc2DbContext(dbOptions);

            var customerRepository = new CustomerRepository(context);
            await customerRepository.AddAsync(customer);

            var result = customerRepository.IsEmailExist(customer.Email, Guid.NewGuid());
            result.Should().BeTrue();


            result = customerRepository.IsEmailExist(customer.Email, customer.Id);
            result.Should().BeFalse();
        }
    }
}
