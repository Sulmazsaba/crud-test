using AutoMapper;
using FluentAssertions;
using Mc2.CrudTest.Application.Customer;
using Mc2.CrudTest.Domain.CustomerModule.Commands;
using MediatR;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.Application.Tests
{
    public class CustomerWriterTests
    {
        private CustomerWriter _customerWriter;
        private IMapper _mapper;
        private readonly Mock<IMediator> _mediator;
        private readonly AddCustomerCommand _addCustomerCommand;

        public CustomerWriterTests()
        {
            _addCustomerCommand = new AddCustomerCommand
            {
                Firstname = "John",
                Lastname = "Snow",
                DateOfBirth = DateTime.Now.AddYears(-20),
                Email = "JohnSnow@gmail.com",
                BankAccountNumber = "122233",
                PhoneNumber = "234234234"
            };


            _mediator = new Mock<IMediator>();

            if (_mapper == null)
            {
                SetMapper();
            }

            _customerWriter = new CustomerWriter(_mediator.Object, _mapper);

        }

        private void SetMapper()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CustomerProfile());
            });

            _mapper = mappingConfig.CreateMapper();
        }

        [Fact]
        public async Task AddCustomer_PassValidValue_ShouldBeSet()
        {

            var result = await _customerWriter.AddCustomer(_addCustomerCommand);


            result.Id.Should().NotBe(null);
            result.Email.Should().Be(_addCustomerCommand.Email);
            result.BankAccountNumber.Should().Be(_addCustomerCommand.BankAccountNumber);
        }
    }
}
