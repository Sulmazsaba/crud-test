using Mc2.CrudTest.Application.Customer;
using Mc2.CrudTest.Domain.CustomerModule;
using Mc2.CrudTest.Domain.CustomerModule.Commands;
using Mc2.CrudTest.Presentation.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Mc2.CrudTest.Presentation.Server.Tests
{
    public class CustomerControllerTests
    {
        private readonly Mock<ICustomerWriter> _customerWriter;
        private readonly Mock<ICustomerReader> _customerReader;
        private readonly CustomersController _customerController;
        private readonly AddCustomerCommand _addCustomerCommand;
        private readonly CustomerDto _customerDto;
        public CustomerControllerTests()
        {
            _customerWriter = new Mock<ICustomerWriter>();
            _customerReader = new Mock<ICustomerReader>();
            _addCustomerCommand = new AddCustomerCommand();
            _customerDto = new CustomerDto();

            _customerController = new CustomersController(_customerWriter.Object, _customerReader.Object);
        }


        [Theory]
        [InlineData(0, false, typeof(BadRequestObjectResult))]
        [InlineData(1, true, typeof(CreatedAtRouteResult))]
        public async Task CreateCustomer_ShouldCallAddCustomerMethodWhenValid(int expectedMethodCalls, bool isModelValid, Type expectedActionResultType)
        {
            //Arrange
            _customerWriter.Setup(i => i.AddCustomer(_addCustomerCommand)).ReturnsAsync(_customerDto);

            if (!isModelValid)
                _customerController.ModelState.AddModelError("key", "ErrorMessage");

            //Action
            ActionResult<CustomerDto> actionResult = await _customerController.CreateCustomer(_addCustomerCommand);


            //Assert
            actionResult.Result.ShouldBeOfType(expectedActionResultType);
            _customerWriter.Verify(i => i.AddCustomer(_addCustomerCommand), Times.Exactly(expectedMethodCalls));
        }
    }
}
